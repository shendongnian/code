    for(int i = 0; i < Request.Files.Count; i++) {
        
        int Size = Request.Files[i].ContentLength / 1024;
        if (Size <= 512)
        {
           string LocalFile = Request.Files[i].FileName;
        //.....
    }
