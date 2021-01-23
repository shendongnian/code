        string conSTR = "Data Source=" + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)) + "\\pruebaDB.sdf;Persist Security Info=False";
        
        SqlCeConnection connection = new SqlCeConnection(conSTR);
        
        string sql = "SELECT * FROM tablaMercancia";
        connection.Open();
        
        SqlCeCommand cmd = new SqlCeCommand(sql, connection);
        SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
        
        //datagridview1 is name of datagridview in form:
        datagridview1.datasourse=da.table(0);
        
        connection.Close();
