    string oldestFile = "";
    DateTime oldestDate = DateTime.Max;
    
    foreach(string fileName in Directory.GetFiles(path))
    {
        DateTime date = ExtractDateTimeFrom(fileName);
        if (date < oldestDate)
        {
            oldestFile = fileName;
            oldestDate = date;
        }
    }
