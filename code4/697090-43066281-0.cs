    private static void Unzip(String sourceFile,String destination) 
    {
    	Shell32.ShellClass sc = new Shell32.ShellClass();
    	Shell32.Folder SrcFlder = sc.NameSpace(sourceFile);
    	Shell32.Folder DestFlder = sc.NameSpace(destination);
    	Shell32.FolderItems items = SrcFlder.Items();
    	DestFlder.CopyHere(items, 20);			
    }
