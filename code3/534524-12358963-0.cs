    static void Main(string[] args)
    {
        Server server = new Server("serverName");
        Database db = server.Databases["DatabaseName"];
        string tableName = "TableName";
        Table table = db.Tables[tableName];
        if (table != null)
        {
            Console.WriteLine("Table:  {0}", tableName);
            if (table.Columns.Count > 0)
            {
                Console.WriteLine("  Primary Key Columns:");
                foreach (Column column in table.Columns)
                {
                    if (column.InPrimaryKey)
                    {
                        Console.WriteLine(string.Format("    {0}", column.Name));
                    }
                }
            }
            else
            {
                Console.WriteLine("  No primary key.", tableName);
            }
        }
        Console.WriteLine("Press ENTER to exit...");
        Console.ReadLine();
    }
