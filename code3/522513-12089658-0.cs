    var nameHelper = new System.Reflection.AssemblyName
        (System.Reflection.Assembly.GetExecutingAssembly().FullName);
    if (Application.Current.Resources.Contains("ApplicationTitle")) 
        Application.Current.Resources.Remove("ApplicationTitle");
    Application.Current.Resources.Add("ApplicationTitle", 
        "FUEL CONSUMPTION - v" + nameHelper.Version.Major + "." +
        nameHelper.Version.Minor);
