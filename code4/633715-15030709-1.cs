    DateTime lowDate = DateTime.Today.AddDays(-1);
    DateTime highDate = DateTime.Today.AddHours(-2.0);
    
    var filteredFileNames = new List<String>();
    string[] fileNames;
    fileNames = Directory.GetFiles(dirPath, "*.xml")
    
    for (int i = 0; i < fileNames.Length; i++)
    {
       var creationTime = File.GetCreationTimeUtc(fileNames[i]);
       if(creationTime >= lowDate && creationTime < highDate)
       {
        filteredFileNames.Add(filenNames[i]);
       }
    }
