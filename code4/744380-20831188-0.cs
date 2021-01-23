    using (ServerManager iisManager = new ServerManager())
    {
        Application app = iisManager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"].Applications[0];
                    
        TimeSpan ts = new TimeSpan(0, 00, 00);
        iisManager.ApplicationPoolDefaults.ProcessModel.IdleTimeout = ts;
        iisManager.CommitChanges();
    }
