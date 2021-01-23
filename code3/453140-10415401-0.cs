    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Excel 8.0; Extended Properties=HDR=YES;Data Source=" + Directory.GetCurrentDirectory() + "/swtlist.xls";
    OleDbConnection oledbConn = new OleDbConnection(connString);
   
    oledbConn.Open();
    DataTable dt = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    OleDbCommand cmd = new OleDbCommand("UPDATE [Sheet1$] SET done='yes' where id=1", oledbConn);
    cmd.ExecuteNonQuery();
