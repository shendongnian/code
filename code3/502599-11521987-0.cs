    var packageDetailFiles = new List<PackageDetailFile>();
    while (Running)
    {
        while (rdr.Read())
        {
            var detailFile = new PackageDetailFile();
            // the following will depend on your data structure and class properties
            detailFile.Property1 = rdr.GetString(0);
            detailFile.Property2 = rdr.GetString(1);
            detailFile.Property3 = rdr.GetString(2);
    
            packageDetailFiles.Add(detailFile);
        }
    }
