    using System.Configuration;
    using System.Web.Configuration;
    Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
    HttpHandlersSection hdlrs = (HttpHandlersSection) config
                                .GetSection("system.web/httpHandlers");
