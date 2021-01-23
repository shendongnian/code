    private void Application_Startup(object sender, StartupEventArgs e)
            {
                if (e.InitParams != null)
                {
                    foreach (var item in e.InitParams)
                    {
                        this.Resources.Add(item.Key, item.Value);
                    }
                }
    
                this.RootVisual = new MainPage();
            }
