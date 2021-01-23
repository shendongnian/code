     using (FileStream fs = new FileStream(@"C:\bad_records.txt", FileMode.Create, FileAccess.Write))
    {
        var badEnumerable = _cache.Where(kvp => !kvp.Value.Item1).ToList();
    
        fs.WriteLine(string.Format("BAD  RECORDS ({0})", badEnumerable.Count));
        fs.WriteLine("==========");
    
        foreach (var item in badEnumerable)
        {
            fs.WriteLine(string.Format("{0}: {1}", item.Key, item.Value.Item2));
        }
    }
