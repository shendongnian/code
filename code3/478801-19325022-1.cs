    #r "System.Configuration"
    
    using System;
    using System.IO;
    using System.Linq;
    
    
    var paths = new[] { Path.Combine(Environment.CurrentDirectory, "Web.config"), Path.Combine(Environment.CurrentDirectory, "App.config") };
    var configPath = paths.FirstOrDefault(p => File.Exists(p));
    
    if (configPath != null)
    {
        // Set new configuration path
    	AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", configPath);  
        // Reset current configuration load state
        var t = typeof(System.Configuration.ConfigurationManager);
        var f = t.GetField("s_initState", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
        f.SetValue(null, 0);
    }
