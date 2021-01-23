        List<string> returnfiles = new List<string>(); // final list
        object lockObj = new object();
        foreach (string drive in drives)
        {
            foreach (string filter in filterlist.Split(','))
            {
                TraverseTreeParallelForEach(drive, filter, (f) =>
                {
                    lock(lockObj)
                    {
                       returnfiles.Add(f);
                    }
                });
            }
        }
        Console.WriteLine("Returnfiles count " + returnfiles.Count);
        returnfiles.RemoveAll(item => item == null); //remove nulls
        return returnfiles;
    }
