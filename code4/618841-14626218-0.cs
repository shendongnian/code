     using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    cn.Open(); 
                    string des="";   
                    SqlCommand cmd = new SqlCommand("select Designation from EmployeeTab where EmpName=name;", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        des = dr["Designation"].ToString() 
                    }
                    dr.Close();
                    cn.Close();
                }
