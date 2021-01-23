    NpgsqlConnection Conn = new NpgsqlConnection(getPostgresConnString());
    Conn.Open();
    NpgsqlCopyIn copyIn = new NpgsqlCopyIn("COPY table  (col1,col2,col2)   FROM STDIN;", Conn);
    copyIn.Start();
    NpgsqlCopySerializer cs1 = new NpgsqlCopySerializer(pConn2);
    cs1.AddString(System.IO.File.ReadAllText("C:\\test\\Web.config"));
    [...]
    cs1.EndRow();
    cs1.Close();
    copyIn.End();
