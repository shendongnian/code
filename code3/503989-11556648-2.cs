    string startFolder = @"c:\program files\Microsoft Visual Studio 9.0\";
    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
    IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
    
            IEnumerable<System.IO.FileInfo> fileQuery =
                from file in fileList
                //where file.CreationTime == DateTime.Now()//replac eyour date here
                orderby file.CreationTime 
                select file;
