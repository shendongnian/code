                            SqlDataReader reader = cmm.ExecuteReader();
                            reader.Close();
                            foreach (SqlParameter prm in cmd.Parameters)
                            {
                               Debug.WriteLine("");
                               Debug.WriteLine("Name " + prm.ParameterName);
                               Debug.WriteLine("Type " + prm.SqlDbType.ToString());
                               Debug.WriteLine("Size " + prm.Size.ToString());
                               Debug.WriteLine("Direction " + prm.Direction.ToString());
                               Debug.WriteLine("Value " + prm.Value);
                            }
