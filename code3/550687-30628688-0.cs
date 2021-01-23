    public class ServiceMain : System.ServiceProcess.ServiceBase
        {
            public const string SERVICE_NAME = "ServiceName";
    
            /// <summary> 
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.Container components = null;
    
            public ServiceMain()
            {
                // This call is required by the Windows.Forms Component Designer.
                InitializeComponent();
            }
    
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                components = new System.ComponentModel.Container();
                this.ServiceName = SERVICE_NAME;
                this.CanPauseAndContinue = true;
            }
    
            static void Main()
            {
                //Log all unhandled exceptions
                AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
                System.ServiceProcess.ServiceBase[] ServicesToRun;
                ServicesToRun = new System.ServiceProcess.ServiceBase[] { new ServiceMain() };
                System.ServiceProcess.ServiceBase.Run(ServicesToRun);
            }
    
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (components != null)
                        components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            /// <summary>
            /// Set things in motion so your service can do its work.
            /// </summary>
            protected override void OnStart(string[] args)
            {
                //Do your stuff here
            }
    
            static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
            {
                Environment.Exit(1);
            }
    }
