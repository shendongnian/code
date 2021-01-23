    public static List<Tuple<string, long>> getFs(string sDir)
    {
        var files = new DirectoryInfo(sDir).GetFiles("*.*", SearchOption.AllDirectories)
            .Where(
                s => ((s.FullName.ToLower().EndsWith(".ai")) ||
                        (s.FullName.ToLower().EndsWith(".psd") && s.Length > 10000000) ||
                        (s.FullName.ToLower().EndsWith(".pdf") && s.Length > 10000000)
                        )
                    )
            .Select(
                        s => new Tuple<string, long>(s.FullName.Replace(sDir, ""), s.Length)
                    );
        return files.ToList();
    }
