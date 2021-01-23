    private class NameAndContents
    {
       public string Text{get;set;}
       public string FileName{get;set;}
    }
    ParallelQuery<NameAndContents> fileContents = from file in fileNames.AsParallel() 
    select new NameAndContents{ Text = File.ReadAllText(file), FileName = Path.GetExtension(file) }; 
