    public static List<string> getFs(string sDir)
    {
    
        var files = Directory.EnumerateFiles(sDir, "*.*", SearchOption.AllDirectories)
            .Where(
                s => ((s.ToLower().EndsWith(".ai")) ||
                      (s.ToLower().EndsWith(".psd") && new FileInfo(s).Length > 10000000) ||
                      (s.ToLower().EndsWith(".pdf") && new FileInfo(s).Length > 10000000)
                     ) 
                   )
           .Select(
                     s => new { s.Replace(sDir, ""), s.Lenght}
                   );   
    
        return files.ToList();
    }
