    public FolderItems Extract()
    {
     var shell = new Shell();
     var sf = shell.NameSpace(_zipFile.Path);
     return sf.Items();
    }
               
