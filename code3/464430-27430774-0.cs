    var servicePath = string.Format("Win32_Service.Name=\"{0}\"", "MyService");
    string pathName = null;
    try
    {
        var wmiObject = new ManagementObject(servicePath);
        pathName = (string)wmiObject.GetPropertyValue("PathName");
    }
    catch {}
    if (pathName != null)
    {
        var invalidChars = new Regex(string.Format(CultureInfo.InvariantCulture, "[{0}]", Regex.Escape(new string(Path.GetInvalidPathChars()))));
        var path = invalidChars.Replace(pathName, string.Empty);
        Console.WriteLine(path);
    }
    else
    {
        Console.WriteLine("Else part...");
    }
