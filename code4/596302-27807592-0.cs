    SortedList<string, string> info = new SortedList<string, string>();
    info.Add("path", "път");
    info.Add("folder", "директория");
    info.Add("directory", "директория");
    info.Add("file", "Файл");
    
    foreach (string key in info.Keys)
    {
     Console.WriteLine("\t{0}\t{1}", key, info[key]);
    }
