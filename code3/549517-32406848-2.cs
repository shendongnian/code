    static void Main(string[] args)
    {
        var parent = Registry.ClassesRoot.OpenSubKey("CLSID");
        var subKeys = parent.GetSubKeyNames();
        foreach (var subKey in subKeys)
        {
            var sub = parent.OpenSubKey(subKey);
            if (sub != null)
            {
                var inProc = sub.OpenSubKey("InProcServer32");
                if (inProc != null)
                {
                    var val = inProc.GetValue(null);
                    if (val != null)
                    {
                        var name = val.ToString();
                        if (!string.IsNullOrWhiteSpace(name))
                            Console.WriteLine(name);
                    }
                }
            }
        }
    }
