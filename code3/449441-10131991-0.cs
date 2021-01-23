    public static string MakeUniqueFileName(string file)
    {
        string dir = Path.GetDirectoryName(file);
        string fn;
        for (int i = 0; ; ++i)
        {
            fn = Path.Combine(dir, string.Format(file, i));
               
            if (!File.Exists(fn))
                return fn;
        }
    }
