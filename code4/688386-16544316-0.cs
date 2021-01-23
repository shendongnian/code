    OleDbConnection conn = null;
    OleDbDataReader reader = null;
    try
    {
        conn = new OleDbConnection(
            "Provider=Microsoft.Jet.OLEDB.4.0; " + 
            "Data Source=" + Server.MapPath("Database/TestDB.mdb"));
        conn.Open();
        OleDbCommand cmd = 
            new OleDbCommand("Select * FROM Table1", conn);
        reader = cmd.ExecuteReader();
        datagrid.DataSource = reader;
        datagrid.DataBind();
    }
        //        catch (Exception e)
        //        {
        //            Response.Write(e.Message);
        //            Response.End();
        //        }
    finally
    {
        if (reader != null)  reader.Close();
        if (conn != null)  conn.Close();
    }
