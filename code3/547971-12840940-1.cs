    DirectoryEntry w3svc = new DirectoryEntry("IIS://" + "localhost" + "/W3SVC");
    //check each site
    foreach (DirectoryEntry site in w3svc.Children)
    {
        foreach (var s in site.Properties)
        {
            try
            {
                ServerState state =
                    (ServerState)
                    Enum.Parse(typeof (ServerState), site.Properties["ServerState"].Value.ToString());
    
                if (state == ServerState.Paused)
                {
                    //Do action
                }
            }
            catch (Exception)
            {
    
            }
    
        }
    }
