      var settings = ConfigurationManager.ConnectionStrings["ConnectionStringName"];
        var Reset = typeof(ConfigurationElement).GetField(
                      "_bReadOnly", 
                      BindingFlags.Instance | BindingFlags.NonPublic);
        Reset .SetValue(settings, false);
        settings.ConnectionString = "Data Source=Something";
