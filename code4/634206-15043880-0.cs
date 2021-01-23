    public List<string[]> users(string table)
        {
            List<string[]> list = new List<string[]>();
            foreach (DataRow item in com.Execute("select * from " + table + ";").Rows)
            {
                list.Add(new string{item["id"].ToString(), item["mail"].ToString(), 
                                                        item["data"].ToString()});
            }
            return list;
        }
