    using System.Configuration;
    using System.Web.Configuration;
    Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
    HttpHandlersSection handlers = (HttpHandlersSection) config
                                   .GetSection("system.web/httpHandlers");
    List<string> forbiddenList = new List<string>();
    // next part untested:
    foreach(HttpHandlerAction handler in handlers.Handlers)
    {
        if(handler.Type.StartsWith("System."))
        {
            forbiddenList.Add(handler.Path);
        }
    }
