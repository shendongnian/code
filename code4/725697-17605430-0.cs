    var changes = rep.GetChangelists(new Options(ChangesCmdFlags.FullDescription, null, -1, ChangeListStatus.Pending, con.UserName));
    foreach (var change in changes)
    {
        Console.WriteLine(change.Id);
        GetOpenedFilesOptions getOpenedFiles = new GetOpenedFilesOptions(GetOpenedFilesCmdFlags.None, change.Id.ToString(), con.Client.Name, con.UserName, -1);
        IList<Perforce.P4.File> fileList = rep.GetOpenedFiles(null, getOpenedFiles);
        foreach (var f in fileList)
        {
            Console.WriteLine(f);
        }
    }
