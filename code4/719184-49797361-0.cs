    public DataTable GetTable()
            {
                string str = "Select * from GL_V";
                OracleCommand cmd = new OracleCommand(str, con);
                cmd.CommandType = CommandType.Text;
                DataTable Dt = OracleHelper.GetDataSet(con, cmd).Tables[0];
    
                return Dt;
            }
    
            public string DataTableToJSONWithJSONNet(DataTable table)
            {
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(table);
                return JSONString;
            }
 
    public static DataSet GetDataSet(OracleConnection con, OracleCommand cmd)
            {
                // create the data set  
                DataSet ds = new DataSet();
                try
                {
                    //checking current connection state is open
                    if (con.State != ConnectionState.Open)
                        con.Open();
    
                    // create a data adapter to use with the data set
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
    
                    // fill the data set
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                   
                    throw;
                }
                return ds;
            }
