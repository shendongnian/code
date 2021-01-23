    void Main()
    {
         using(OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + 
                @"Data Source=D:\temp\temp.mdb;Persist Security Info=False;")) 
         { 
           con.Open();
           DataTable schema = con.GetSchema("Columns");
           foreach(DataRow row in schema.Rows)
               Console.WriteLine("TABLE:" + row.Field<string>("TABLE_NAME") + 
                                 " COLUMN:" + row.Field<string>("COLUMN_NAME"));
        }
    }
