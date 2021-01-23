    static void Main(string[] args)
    {
        Console.WriteLine("The following .NET versions are installed:");
        var vers = SearchRegistry(Registry.LocalMachine, "Software\\Microsoft\\NET Framework Setup\\NDP", "Version")
            .GroupBy(v => v)
            .Select(v => (string)v.Key)
            .OrderBy(s => s);
        foreach (string s in vers)
            Console.WriteLine(s);
        Console.WriteLine(string.Format("Newest Installed .NET version: {0}", vers.Last()));
    }
    private static IEnumerable<object> SearchRegistry(RegistryKey root, string subkey, string search)
    {
        foreach (string sub in root.OpenSubKey(subkey).GetSubKeyNames())
        {
            foreach (string val in root.OpenSubKey(subkey).OpenSubKey(sub).GetValueNames())
                if (val == search)
                    yield return root.OpenSubKey(subkey).OpenSubKey(sub).GetValue(val);
            foreach (var o in SearchRegistry(root.OpenSubKey(subkey), sub, search))
                yield return o;
        }
    }
