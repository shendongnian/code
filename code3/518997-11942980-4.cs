    // initialize this variable only one time
    DateTime yesterday = DateTime.Today.AddDays(-1); 
    
    foreach (FileInfo flInfo in directory.GetFiles())
    {
        // use directly flInfo.CreationTime and flInfo.Name 
        // without creating another variable
        if (flInfo.CreationTime.Date == yesterday.Date)
        {
            yesterdaysList.Add(flInfo.Name.Substring(3,4));
        }
    }
