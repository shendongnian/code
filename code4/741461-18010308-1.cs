    public Form1()
            {
             InitializeComponent();
             Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            }
     void Application_ApplicationExit(object sender, EventArgs e)
          {
            Process.GetCurrentProcess().Kill();
          }
