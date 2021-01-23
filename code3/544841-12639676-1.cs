    static void CreateAppPool(string metabasePath, string appPoolName)
    {
        //  metabasePath is of the form "IIS://<servername>/W3SVC/AppPools"
        //    for example "IIS://localhost/W3SVC/AppPools" 
        //  appPoolName is of the form "<name>", for example, "MyAppPool"
        Console.WriteLine("\nCreating application pool named {0}/{1}:", metabasePath, appPoolName);
    
        try
        {
            if (metabasePath.EndsWith("/W3SVC/AppPools"))
            {
                DirectoryEntry apppools = new DirectoryEntry(metabasePath);
                DirectoryEntry newpool = apppools.Children.Add(appPoolName, "IIsApplicationPool");
                newpool.CommitChanges();
            }
            else
            {
                Console.WriteLine(" Failed in CreateAppPool; application pools can only be created in the */W3SVC/AppPools node.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed in CreateAppPool with the following exception: \n{0}", ex.Message);
        }
    }
