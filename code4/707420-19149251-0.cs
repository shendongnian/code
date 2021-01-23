    static void Main(string[] args)
    {
        Server sourceServer = new Server("server");
        String dbName = "database"; 
    
        // Connect to the local, default instance of SQL Server. 
    
        // Reference the database.  
        Database db = sourceServer.Databases[dbName];
    
        // Define a Scripter object and set the required scripting options. 
        Scripter scripter = new Scripter(sourceServer);
        scripter.Options.ScriptDrops = false;
        scripter.Options.WithDependencies = true;
        scripter.Options.Indexes = true;   // To include indexes
        scripter.Options.DriAllConstraints = true;   // to include referential constraints in the script
    
        // Iterate through the tables in database and script each one. Display the script.   
        foreach (Table tb in db.Tables)
        {
            // check if the table is not a system table
            if (tb.IsSystemObject == false)
            {
                Console.WriteLine("-- Scripting for table " + tb.Name);
    
                // Generating script for table tb
                System.Collections.Specialized.StringCollection sc = scripter.Script(new Urn[] { tb.Urn });
                foreach (string st in sc)
                {
                    //ado.net to destination 
                    Console.WriteLine(st);//SqlCommand.ExecuteNonQuery();
                }
                Console.WriteLine("--");
            }
        }
    }
