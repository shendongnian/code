    using (var archive = ZipFile.OpenRead("bla.zip"))
    {
        foreach (var s in archive.Entries)
        {
            if (s.IsFolder())
            {
                // do something special
            }
                        
        }
     }
