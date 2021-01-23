    public static List<SvnFile> GetSvnFiles(this SvnClient client, string uri_path)
    {
        // get logitems
        Collection<SvnLogEventArgs> logitems;
        client.GetLog(new Uri(uri_path), out logitems);
        var result = new List<SvnFile>();
        // get craation date for each
        foreach (var logitem in logitems.OrderBy(logitem => logitem.Time))
        {
            foreach (var changed_path in logitem.ChangedPaths)
            {
                string filename = Path.GetFileName(changed_path.Path);
                if (changed_path.Action == SvnChangeAction.Add)
                {
                    result.Add(new SvnFile() { Name = filename, Created = logitem.Time });
                }
            }
        }
        return result;
    }
