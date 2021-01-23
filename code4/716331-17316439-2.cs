    DataTable getdt(){
    MySqlConnection conn = null;
                MySqlDataAdapter da ;
                DataTable dt = new DataTable();
                String sql="select id,name,email from tablename ";
                conn = new MySqlConnection(cs);
                da=new MySqlDataAdapter(sql,conn);
                
               
                
                conn.Open();
                try
                {
                    DataSet dsl = new DataSet();
                    da.Fill(dsl,"Table");
                    dt = dsl.Tables["Table"];
                    return dt;
                }
                catch (MySqlException ex)
                {
                    String err = ex.Message;
                    return dt;
                }
                  } 
