    #r "System.Configuration"
    
    using System;
    using System.IO;
    using System.Linq;
    
    
    var paths = new[] { Path.Combine(Environment.CurrentDirectory, "Web.config"), Path.Combine(Environment.CurrentDirectory, "App.config") };
    var configPath = paths.FirstOrDefault(p => File.Exists(p));
    
    if (configPath != null)
    	AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configPath);  
