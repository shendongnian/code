      public class SingleInstanceController
        : WindowsFormsApplicationBase
      {
        public SingleInstanceController()
        {
          // Set whether the application is single instance
          this.IsSingleInstance = true;
    
          this.StartupNextInstance += new
            StartupNextInstanceEventHandler(this_StartupNextInstance);
        }
    
        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
          // Here you get the control when any other instance is
          // invoked apart from the first one.
          // You have args here in e.CommandLine.
    
          // You custom code which should be run on other instances
        }
    
        protected override void OnCreateMainForm()
        {
          // Instantiate your main application form
          this.MainForm = new Form1();
        }
      }
    [STAThread]
    static void Main(string[] args)
    {    
      SingleInstanceController controller = new SingleInstanceController();
      controller.Run(args);
    }
