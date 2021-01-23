    public static bool CreateSingleInstance( string name, EventHandler<InstanceCallbackEventArgs> callback )
        {
            EventWaitHandle eventWaitHandle = null;
            int curSessionId = System.Diagnostics.Process.GetCurrentProcess().SessionId;
            name += curSessionId;
           
            string eventName = string.Format( "{0}-{1}", Environment.MachineName, name );
           // If there is another instance
            InstanceProxy.IsFirstInstance = false;
            
            InstanceProxy.CommandLineArgs = Environment.GetCommandLineArgs();
            try
            {
                //try to open a handle with the eventName
                eventWaitHandle = EventWaitHandle.OpenExisting( eventName );
            }
            catch
            {
                InstanceProxy.IsFirstInstance = true;
            }
            if( InstanceProxy.IsFirstInstance )
            {
               
                eventWaitHandle = new EventWaitHandle( false, EventResetMode.AutoReset, eventName );
                // register wait handle for this instance (process)               
                ThreadPool.RegisterWaitForSingleObject( eventWaitHandle, WaitOrTimerCallback, callback, Timeout.Infinite, false );
                eventWaitHandle.Close();
                // register shared type (used to pass data between processes)          
                RegisterRemoteType( name );
            }
            else
            {
              // here will be the code for the second instance/
            }
         
            return InstanceProxy.IsFirstInstance;
        }
        private static void RegisterRemoteType( string uri )
        {
            // register remote channel (net-pipes)
            var serverChannel = new IpcServerChannel( Environment.MachineName + uri );
            ChannelServices.RegisterChannel( serverChannel, true );
            // register shared type
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof( InstanceProxy ), uri, WellKnownObjectMode.Singleton );
            // close channel, on process exit
            Process process = Process.GetCurrentProcess();
            process.Exited += delegate
            {
                ChannelServices.UnregisterChannel( serverChannel );
            };
        }
    [Serializable]
    [System.Security.Permissions.PermissionSet( System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust" )]
    internal class InstanceProxy : MarshalByRefObject
    {
        private static bool firstInstance;
        private static string[] arrCommandLineArgs;       
        public static bool IsFirstInstance
        {
            get
            {
                return firstInstance;
            }
            set
            {
                firstInstance = value;
            }
        }     
        public static string[] CommandLineArgs
        {
            get
            {
                return arrCommandLineArgs;
            }
            set
            {
                arrCommandLineArgs = value;
            }
        }
       
        public void SetCommandLineArgs( bool isFirstInstance, string[] commandLineArgs )
        {
            firstInstance = isFirstInstance;
            arrCommandLineArgs = commandLineArgs;
        }
    }
    public class InstanceCallbackEventArgs : EventArgs
    {
        private  bool firstInstance;
        private  string[] arrCommandLineArgs;
     
        internal InstanceCallbackEventArgs( bool isFirstInstance, string[] commandLineArgs )
        {
            firstInstance = isFirstInstance;
            arrCommandLineArgs = commandLineArgs;
        }
      
        public bool IsFirstInstance
        {
            get
            {
                return firstInstance;
            }
            set
            {
                firstInstance = value;
            }
        }
        public string[] CommandLineArgs
        {
            get
            {
                return arrCommandLineArgs;
            }
            set
            {
                arrCommandLineArgs = value;
            }
        }
    }
