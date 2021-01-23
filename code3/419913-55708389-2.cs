    private void Application_Startup(object sender, StartupEventArgs e)
    {
        foreach(string s in e.Args)
        {
            MessageBox.Show(s);
        }
    }
