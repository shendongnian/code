    DateTime yesterday = DateTime.Today.AddDays(-1); //initialize this variable only one time
    
    foreach (FileInfo flInfo in directory.GetFiles()){
        if (flInfo.CreationTime.Date == yesterday.Date) //use directly flInfo.CreationTime and flInfo.Name without create another variable 
           yesterdaysList.Add(flInfo.Name.Substring(3,4));
    }
