                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT EmpId,EmpName,EmpSalary FROM EmpDetails where EmpId=@ID and EmpName=@Name and  EmpSalary=@sal";
                SqlParameter paraId = new SqlParameter();
                paraId.ParameterName = "@id";
                paraId.SqlDbType = SqlDbType.Int;
                paraId.Size = 32;
                SqlParameter paraName = new SqlParameter();
                paraName.ParameterName = "@name";
                paraName.SqlDbType = SqlDbType.VarChar;
                paraName.Size = 50;
                SqlParameter paraSal = new SqlParameter();
                paraSal.ParameterName = "@sal";
                paraSal.SqlDbType = SqlDbType.Decimal;
                paraSal.Precision = 7;
                paraSal.Scale = 2;
                
                //i assume you forgot to setup parameter values.
                paraId.Value = 1;
                paraName.Value = "thisName";
                paraSal.Value = 343;
               
                
                cmd.Parameters.Add(paraId);
                cmd.Parameters.Add(paraName);
                cmd.Parameters.Add(paraSal);
                
                con.Open();
                cmd.Prepare();
                SqlDataReader dr = cmd.ExecuteReader();
                string str = "";
                while (dr.Read())
                {
                    string id = dr.GetInt32(0).ToString();
                    string name = dr.GetString(1);
                    string sal = dr.IsDBNull(2) ? "is null" : dr.GetDecimal(2).ToString();
                    str += id + "\t" + name + "\t" + sal + "\n";
                }
                MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
