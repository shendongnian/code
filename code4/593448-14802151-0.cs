    public static void Insert(this SqlConnection conn, object p)
            {
                string query = "INSERT INTO {0} ({1}) VALUES ({2})";
                conn.Open();
    
                using (SqlCommand command = conn.CreateCommand())
                {
                    PropertyInfo[] propertyInfos;
                    propertyInfos = p.GetType().GetProperties();
                        
                    var objF = String.Join(",", propertyInfos.Select(i => i.Name).ToArray());
                    //var objV = String.Join(",", propertyInfos.Select(i => i.GetValue(p, null)).ToArray());
    
                    var objV = "";
                    string[] array = new string[p.GetType().GetProperties().Count()];
                    foreach (PropertyInfo info in p.GetType().GetProperties())
                    {
                        if (info.GetValue(p,null).GetType() == typeof(string))
                        {
                            objV += "'"+(string)info.GetValue(p, null) + "',";
                        }
                        else if (info.GetValue(p, null).GetType() == typeof(DateTime))
                        {
                            objV += "CAST('" + ((DateTime)info.GetValue(p, null)).ToString("yyyy-MM-dd hh:mm:ss")+ "' AS DATETIME),";
                        }
                        else if (info.GetValue(p, null).GetType() == typeof(bool))
                        {
                            objV += "'" + ((bool)info.GetValue(p, null) == true ? "1" : "0") +"',";
                        }
                        else
                        {
                            objV += "'" + (string)info.GetValue(p, null) + "',";
                        }
                    }
                        
                    command.CommandText = string.Format(string.Format(query, p.GetType().Name, objF, objV.TrimEnd(new char[] { ',' })));
                    command.ExecuteNonQuery();
                }
                conn.Close();
    
            }
