    //
    
    // Enumerate shares on local computer
    
    //
    
    Console.WriteLine("\nShares on local computer:");
    ShareCollection shi = ShareCollection.LocalShares;
    if (shi != null) 
    {
        foreach(Share si in shi) 
        {
            Console.WriteLine("{0}: {1} [{2}]", 
                si.ShareType, si, si.Path);
    
            // If this is a file-system share, try to
    
            // list the first five subfolders.
    
            // NB: If the share is on a removable device,
    
            // you could get "Not ready" or "Access denied"
    
            // exceptions.
    
            if (si.IsFileSystem) 
            {
                try 
                {
                    System.IO.DirectoryInfo d = si.Root;
                    System.IO.DirectoryInfo[] Flds = d.GetDirectories();
                    for (int i=0; i < Flds.Length && i < 5; i++)
                        Console.WriteLine("\t{0} - {1}", i, Flds[i].FullName);
    
                    Console.WriteLine();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("\tError listing {0}:\n\t{1}\n", 
                        si, ex.Message);
                }
            }
        }
    }
    else
        Console.WriteLine("Unable to enumerate the local shares.");
    
    //
    
    // Resolve local paths to UNC paths.
    
    //
    
    Console.WriteLine("{0} = {1}", 
        fileName, ShareCollection.PathToUnc(fileName));
