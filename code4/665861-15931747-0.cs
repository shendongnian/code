    private long GetLatestRevisionNumber(Uri myUri)
    {
        using (SvnClient client = GetClient())
        {
            SvnInfoEventArgs info;
            client.GetInfo(myUri, out info);
            return info.LastChangeRevision;
        }
    }
