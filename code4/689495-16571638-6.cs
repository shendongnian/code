    public List<MyDataContract>  GetData()
    {
        List<MyDataContract> list = new List<MyDataContract>();
        //your code
    
        if (sqlReader != null)
        {
            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    list.Add(new MyDataContract() { 
                        Id = (int)sqlReader["Id"].ToString(), 
                        Name= sqlReader = sqlReader["Name"].ToString() });
    
                }
                sqlConn.Close();
            }
        }
    
        //finally return list of data
    
        return list;
    }
