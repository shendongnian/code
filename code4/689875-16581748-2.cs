    SPWebService service = SPFarm.Local.Services.GetValue<SPWebService>();
        foreach (SPWebApplication webapp in service.WebApplications)
        {
            Console.WriteLine("WebApplication : " + webapp.Name);
            foreach (SPContentDatabase db in webapp.ContentDatabases)
            {
                Console.WriteLine("{0}, Nb Sites : {1}, Size : {2}, ", db.Name, db.Sites.Count, db.DiskSizeRequired);
            }
        }
