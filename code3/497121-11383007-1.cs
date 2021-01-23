    ServerManager manager = new ServerManager();
        foreach (Site site in manager.Sites)
        {
            foreach (Application app in site.Applications)
            {
                if (app.ApplicationPoolName.ToString() == AppPoolName)
                {
                     string appname = app.Path;
                }
            }
        }
