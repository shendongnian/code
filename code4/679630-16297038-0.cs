    var sr = new StreamReader("filelist.txt");
    while(!sr.EOF)
    {
        string[] ListFiles = Directory.GetFiles("D:\movies\", 
                                                sr.ReadLine()/*your file name is the search pattern*/, 
                                                SearchOption.AllDirectories);
        if(ListFIles.Count > 0)
        {
            //File Found
            foreach(var f in ListFiles)
            {
                string fullPath = Path.GetFullPath(file);
                string fileName = Path.GetFileName(fullPath);
            }
            
        }
        
    }
