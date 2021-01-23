    Server srv = new Server(conn);
    Database db = srv.Databases["AdventureWorks"];
    
    foreach (Table table in db.Tables)
    {
        Console.WriteLine(" " + table.Name);
        foreach (Column col in table.Columns)
        {
            Console.WriteLine("  " + col.Name + " " + col.DataType.Name);
        }
    }
