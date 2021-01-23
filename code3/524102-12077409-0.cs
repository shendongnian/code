    Type t = Type.GetTypeFromProgID("Shell.Application");
    dynamic shell = Activator.CreateInstance(t);
    //This is browse through all the items in the folder
    var objFolder = shell.NameSpace(@"\\fileshares\Files\test");
    foreach (var item in objFolder.Items())
    {
        //This is to get the file's comments for each files in the folderitem
                    
        string file_version = objFolder.GetDetailsOf(item, 14).ToString();
         Console.WriteLine(file_version);
    }
   
