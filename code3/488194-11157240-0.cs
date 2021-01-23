    public static List<string> GetHostNamesPerSite(string siteName)
    {
      using (ServerManager sm = new ServerManager())
      {
        Site site = sm.Sites.First(s => s.Name == siteName);
        return site.Bindings.Select(s => s.Host).ToList();
      }
    }
