     public void refreshGrid1()
        {
            openDatabase();
            SqlCommand readcmd = new SqlCommand();
            readcmd.Connection = connection;
            readcmd.CommandType = CommandType.Text;
            readcmd.CommandText = "SELECT * FROM Table1";
            SqlDataReader reader = null;
            reader = readcmd.ExecuteReader();
            closeDatabase();
            gridView.DataBind();
        }
