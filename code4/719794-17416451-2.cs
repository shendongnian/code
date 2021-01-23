    Dictionary<string, string> d = new Dictionary<string, string>();
    
                foreach (DataRow dr in table.Rows)
                {
                    string key=dr["ClassID"].ToString() + "-" + dr["ClassName"].ToString();
                    string value=dr["StudentID"].ToString() + "-" + dr["StudentName"].ToString();
                    if (!d.ContainsKey(key))
                    {
                        d.Add(key, value);
                    }
                   
                }
