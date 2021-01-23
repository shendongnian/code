    var directory = new DirectoryInfo(Path.GetDirectoryName(@"--DIR Path--"));
    DateTime from_date = DateTime.Now.AddDays(-5);
    DateTime to_date = DateTime.Now.AddDays(5);
    
    //For Today 
    var filesLst = directory.GetFiles().AsEnumerable()
                  .Where(file.CreationTime.Date == DateTime.Now.Date ).ToArray(); 
    
    //For date range + specific file extension 
    var filesLst = directory.GetFiles().AsEnumerable()
                  .Where(file => file.CreationTime.Date >= from_date.Date && file.CreationTime.Date <= to_date.Date && file.Extension == ".txt").ToArray(); 
    
    //To get ReadOnly files from directory  
    var filesLst = directory.GetFiles().AsEnumerable()
                  .Where(file => file.IsReadOnly == true).ToArray(); 
    
    //To get files based on it's size
    int fileSizeInKB = 100; 
    var filesLst = directory.GetFiles().AsEnumerable()
                  .Where(file => (file.Length)/1024 > fileSizeInKB).ToArray(); 
