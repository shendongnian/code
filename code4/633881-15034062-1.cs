    // Example appSetting element:
    //   <add key="examplePath" value="%APPDATA%\example.txt" />
    string path = System.Configuration.ConfigurationManager.AppSettings["examplePath"].ToString();
    path = Environment.ExpandEnvironmentVariables(path);
    System.IO.File.WriteAllText(path, "foobar");
