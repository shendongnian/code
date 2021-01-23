    using Microsoft.Web.Administration;
    using System.Web.Hosting;
    ServerManager mgr = new ServerManager();
    String SiteName = HostingEnvironment.ApplicationHost.GetSiteName();
    Site currentSite = mgr.Sites[SiteName];
    //The following obtains the application name and application object
    //The application alias is just the application name with the "/" in front
    String ApplicationAlias = HostingEnvironment.ApplicationVirtualPath;
    String ApplicationName = ApplicationAlias.Substring(1);
    Application app = currentSite.Applications[ApplicationAlias];
    //And if you need the app pool name, just use app.ApplicationPoolName
