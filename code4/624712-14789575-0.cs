    <%       SqlConnection con = new   SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString());
             string cmdText = _id != null
                                ? @"SELECT * FROM Customers where id= @_id"
                                : @"SELECT * FROM Customers where customerName= @custName_";
             SqlCommand cmd = new SqlCommand(cmdText, con);
             cmd.Parameters.Add("_id", SqlDbType.Int).Value = Convert.ToInt16(Request["id"].ToString());
             cmd.Parameters.Add("custName_",SqlDbType.VarChar).Value=Convert.ToChar(Request["custName"].ToString());
             DataTable dt = new DataTable();
             con.Open();
             dt.Load(cmd.ExecuteReader());
             con.Close();
