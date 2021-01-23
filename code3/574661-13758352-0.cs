    SvnInfoEventArgs statuses;
    SvnClient client = new SvnClient();
    client.Authentication.Clear();//clear a previous authentication
    client.Authentication.DefaultCredentials = 
        new System.Net.NetworkCredential("usr", "pass");
    client.GetInfo("svn://india00/Repo/branches/xyz", out statuses);
    int LastRevision = (int)statuses.LastChangeRevision;`
