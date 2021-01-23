    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    var exe = Assembly.GetExecutingAssembly();
    string resourceName = exe.GetManifestResourceNames()
                             .FirstOrDefault(s => s.IndexOf("NLog.config", StringComparison.OrdinalIgnoreCase) > -1);
    if (!string.IsNullOrEmpty(resourceName))
    {
      using (var xml = new StreamReader(exe.GetManifestResourceStream(resourceName)))
      {
        string xmlConfig = xml.ReadToEnd();
        if (!File.Exists("NLog.config"))
        {
          // Do something with the log file, like write it out to the root directory.
          File.WriteAllText("NLog.config", xmlConfig);
        }
      }
    }
