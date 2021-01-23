    public class BasicAuthFeature : IPlugin 
    {
        public string HtmlRedirect { get; set; }   //User-defined configuration
        public void Register(IAppHost appHost)
        {
            //Register Services exposed by this module
            appHost.RegisterService<AuthService>("/auth", "/auth/{provider}");
            appHost.RegisterService<AssignRolesService>("/assignroles");
            appHost.RegisterService<UnAssignRolesService>("/unassignroles");
            //Load dependent plugins
            appHost.LoadPlugin(new SessionFeature());
        }
    }
