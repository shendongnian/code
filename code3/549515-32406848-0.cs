    static void Main(string[] args)
    {
        var parent = Registry.ClassesRoot.OpenSubKey("CLSID");
        var subKeys = parent.GetSubKeyNames();
        foreach (var subKey in subKeys)
        {
            var sub = parent.OpenSubKey(subKey);
            var inProc = sub.OpenSubKey("InProcServer32");
            var val = inProc.GetValue(null);
            var name = val.ToString();
            if (!string.IsNullOrWhiteSpace(name))
                Console.WriteLine(name);
        }
    }
