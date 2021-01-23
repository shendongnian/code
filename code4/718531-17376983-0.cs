    DataTable servers = SmoApplication.EnumAvailableSqlServers(true);
    
    foreach (DataRow server in servers.Rows)
    {
        Console.WriteLine(server[Name] + " " + server[Server]);
        foreach(Database database in server.Databases){
            Console.WriteLine(database.Name);
            foreach (Table tb in database.Tables) {
	            Console.WriteLine(tb.Name);
           }
        }
    }
