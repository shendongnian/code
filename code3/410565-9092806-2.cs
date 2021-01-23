    using GM.Powertrain.RemoteCopy.Interfaces; 
    using System.Runtime.Remoting.Channels.Tcp; 
    using System.Runtime.Remoting.Channels; 
    
    namespace ProjectName
    {
        static class Program
        {
            private static ServiceConfig serviceConfig = serviceConfig.Load();
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMainCard());
                Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            }
    
            public static ServiceConfig Conifg
            {
                get { return serviceConfig; }
            }
    
            public static IRemoteCopier LocalMachine
            {
                get { return serviceConfig.GetObject<IRemoteCopier>("localhost"); }
            }
    
            static void Application_ApplicationExit(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
        }
    }
