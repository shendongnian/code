                cn = new SqlConnection(@"Data Source=Nick-PC\SQLEXPRESS;Initial         Catalog=AutoDB;Integrated Security=True");
                cmd= new SqlCommand("select * from TblState",cn);
                cn.Open();
                SqlDataReader dr;
    
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
    
                    {
                        SelectState.Items.Add(dr["State"].ToString());
                    }
    
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
                finally
                {
                    cn.Close();
                }
    
 
                //To fill the Cities from City Table
                // To fill the Data in the Pincode from the City Table
                cn2 = new SqlConnection(@"Data Source=Nick-PC\SQLEXPRESS;Initial Catalog=AutoDB;Integrated Security=True");
                cmd2 = new SqlCommand("SELECT * FROM TblCity ", cn2);
                cn2.Open();
                SqlDataReader dm;
    
                try
                {
                    dm = cmd2.ExecuteReader();
                    while (dm.Read())
                    {
                        SelectPinCode.Items.Add(dm["Pincode"].ToString());
    //since you are using only one City table to get PinCode and City name then this would be better.
                        SelectCity.Items.Add(ds["City"].ToString());
                    }
    
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
                finally
                {
                    cn2.Close();
                }
