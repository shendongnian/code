    static public IEnumerable<string> Match(string startfilelocation, Func<string,bool> predicate)
    {
        var filelist = Directory.GetFiles(startfilelocation, "*.*", SearchOption.AllDirectories);
        return filelist.Where(predicate);
    }
    static public IEnumerable<string> Match(string startfilelocation, Func<string,int,bool> predicate)
    {
        var filelist = Directory.GetFiles(startfilelocation, "*.*", SearchOption.AllDirectories);
        return filelist.Where(predicate);
    }
