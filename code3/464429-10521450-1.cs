    string ServicePath = string.Format("Win32_Service.Name=\"{0}\"", "MyService");
    var WMiObject = new ManagementObject(ServicePath);
    PropertyInfo PInfo = typeof(ManagementObject).GetProperty("IsBound", BindingFlags.NonPublic | BindingFlags.Instance);
    if ((bool)PInfo.GetValue(WMiObject, null))
    {
        string PathName = (string)WMiObject.GetPropertyValue("PathName");
        var invalidChars = new Regex(string.Format(CultureInfo.InvariantCulture, "[{0}]", Regex.Escape(new string(Path.GetInvalidPathChars()))));
        var path = invalidChars.Replace(PathName, string.Empty);
        Console.WriteLine(path);
    }
    else
    {
        Console.WriteLine("Else part...");
    }
       
