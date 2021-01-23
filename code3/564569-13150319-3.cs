    using IrcServiceLibrary;
    using System.Collections.Generic;
    using System.ServiceProcess;
    using System.Threading;
    using System.Xml;
    
    namespace IrcServiceHost
    {
      internal static class Program
      {
        /// <summary>
        /// Launches as an application when an argument "app" is supplied.
        /// Otherwise launches as a Windows Service.
        /// </summary>
        private static void Main(string[] arg)
        {
          var args = new List<string>(arg);
          ServiceBase[] ServicesToRun = new ServiceBase[]
          {
            new IrcServiceLibrary.Irc(
                Properties.Settings.Default.IrcTcpPort)
              };
          if (args.Contains("app"))
          {
            foreach (IExecutableService es in ServicesToRun)
              es.StartService();
            Thread.Sleep(Timeout.Infinite);
          }
          else
          {
            ServiceBase.Run(ServicesToRun);
          }
        }
      }
    }
