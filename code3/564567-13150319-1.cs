    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.ServiceModel;
    using System.ServiceProcess;
    using System.Threading;
    
    namespace IrcServiceLibrary
    {
      /// <summary>
      /// Listens for TCP connection establishment and creates an 
      /// IrcSession object to handle the test session.
      /// </summary>
      [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
      public partial class Irc : ServiceBase, IExecutableService
      {
        AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        TcpListener _tcpListener;
        List<IrcSession> _sessions = new List<IrcSession>();
    
        /// <summary>
        /// Creates Irc and applies configuration supplied by the service host.
        /// </summary>
        /// <param name="tcpPort">Port on which the session is established.</param>
        public Irc(int tcpPort)
        {
          Trace.TraceInformation("NetReady service created {0}", GetHashCode());
          InitializeComponent();
          _tcpListener = new TcpListener(IPAddress.Any, tcpPort); 
          NetReadySession.Sessions = _sessions;
        }
    
        void AcceptTcpClient(IAsyncResult asyncResult)
        {
          var listener = asyncResult.AsyncState as TcpListener;
          var tcpClient = listener.EndAcceptTcpClient(asyncResult);
          try
          {
            new NetReadySession(tcpClient);
          }
          catch (IndexOutOfRangeException)
          {
            //no free session - NetReadySession ctor already informed client, no action here
          } 
          _tcpListener.BeginAcceptTcpClient(AcceptTcpClient, _tcpListener);
        }
    
        /// <summary>
        /// <see cref="StartService">ServiceStart</see> 
        /// </summary>
        /// <param name="args">Arguments passed by the service control manager</param>
        protected override void OnStart(string[] args)
        {
          StartService();
        }
    
        /// <summary>
        /// <see cref="StopService">ServiceStop</see> 
        /// </summary>
        protected override void OnStop()
        {
          StopService();
        }
    
        void Execute(object state)
        {
          Trace.TraceInformation("IRC service started");
          _tcpListener.Start();
          _tcpListener.BeginAcceptTcpClient(AcceptTcpClient, _tcpListener);
          _autoResetEvent.WaitOne();
          _tcpListener.Stop();
        }
    
        internal static int UdpPortLow { get; set; }
    
        internal static int UdpPortHigh { get; set; }
    
        /// <summary>
        /// Starts the service. OnStart uses this method to implement startup behaviour.
        /// This guarantees identical behaviour across application and service modes.
        /// </summary>
        public void StartService()
        {
          ThreadPool.QueueUserWorkItem(Execute);
        }
    
        /// <summary>
        /// Stops the service. OnStop uses this method to implement shutdown behaviour.
        /// This guarantees identical behaviour across application and service modes.
        /// </summary>
        public void StopService()
        {
          _autoResetEvent.Set();
        }
      }
    }
