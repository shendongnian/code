    SqlCeConnection conn = null;
    try
    {
        conn = new SqlCeConnection("Data Source = bd-avalia.sdf; Password ='<asdasd>'");
        conn.Open();
        SqlCeCommand cmd = conn.CreateCommand();
        cmd.CommandText = "CREATE TABLE dbo.[cliente] ([id_cliente] [int] IDENTITY(1,1)  NOT NULL PRIMARY KEY, 
                           nome [varchar] NOT NULL, password [int] NOT NULL)";
        cmd.ExecuteNonQuery();
    }
    finally
    {
        conn.Close();
    }
