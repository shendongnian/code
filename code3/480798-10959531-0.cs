    SqlConnection conn = new SqlConnection(CONNECTIONSTRING);
    conn.Open();
    
    SqlCommand cmd = conn.CreateCommand();
    cmd.CommandText = "SET SHOWPLAN_ALL ON";
    cmd.ExecuteNonQuery();
    cmd.CommandText = "SELECT [Field1], [Field2] FROM [TableName]";
    
    DataTable dt = new DataTable();
    dt.Load(cmd.ExecuteReader());
    
    Regex objectRegex = new Regex(@"^OBJECT:\(\[(?<database>[^\]]+)\]\.\[(?<schema>[^\]]+)\]\.\[(?<table>[^\]]+)\]\.\[(?<field>[^\]]+)\]\)$", RegexOptions.ExplicitCapture);
    
    List<string> lstTables = new List<string>();
    foreach (DataRow row in dt.Rows)
    {
        string argument = row["Argument"].ToString();
        if (!String.IsNullOrEmpty(argument))
        {
            Match m = objectRegex.Match(argument);
            if (m.Success)
            {
                string table = m.Groups["schema"] + "." + m.Groups["table"];
                if (!lstTables.Contains(table))
                {
                    lstTables.Add(table);
                }
            }
        }
    }
    
    Console.WriteLine("Query uses the following tables: " + String.Join(", ", lstTables));
