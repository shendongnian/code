    string filename= //yourfilePath;
        string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ filename +";Extended Properties=dBASE IV;User ID=Admin;Password=;";
    DataTable dt = new DataTable();   
     using (OleDbConnection con = new OleDbConnection(constr))
                    {
                        var sql = "select * from " + filename ;
                        OleDbCommand cmd = new OleDbCommand(sql, con);
                        con.Open();
                        DataSet ds = new DataSet(); ;
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        da.Fill(ds);
    dt  =ds.Tables[0]
                    }
