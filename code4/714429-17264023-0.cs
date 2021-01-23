    class SingleInstanceApp : WindowsFormsApplicationBase
    {
        public SingleInstanceApp()
            : base()
        {
            this.IsSingleInstance = true;
        }
     
        protected override void OnStartupNextInstance(
            StartupNextInstanceEventArgs e)
        {
            base.OnStartupNextInstance(e);
     
            string[] secondInstanceArgumens = e.CommandLine.ToArray();
     
            // Handle command line arguments of second instance
     
            if (e.BringToForeground)
            {
                this.MainForm.BringToFront();
            }
        }
    }
