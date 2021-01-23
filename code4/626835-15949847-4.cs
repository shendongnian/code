    public long GetLatestRevisionNumber(Uri svnPath)
    {
        using (SvnClient client = GetClient())
        {
            SvnInfoEventArgs info;
            client.GetInfo(svnPath, out info);
            return info.LastChangeRevision;
         }
    }
