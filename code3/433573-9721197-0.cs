    void Main()
    {
        Server server = new Server("server");
        Database db = server.Databases["database"];
        
        string sprocName = "StoredProcName";
    
        StoredProcedure proc = db.StoredProcedures[sprocName];
        if (proc != null)
        {
            foreach (StoredProcedureParameter parameter in proc.Parameters)
            {
                Console.WriteLine("{0}:  {1}", parameter.DataType.Name, parameter.Name);
            }
            Console.WriteLine(proc.TextBody);
        }
    }
