    void GetRecords2()
    {         
        Dictionary <int, string> myDict = new Dictionary<int, string>();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandText = "SELECT CustomerID, firstname, lastname FROM Customer";
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
           myDict.Add(Convert.ToInt32(reader["CustomerID"]), 
                reader["firstname"].ToString() + " " + reader["lastname"].ToString());
        }
        if (myDict.Count > 0)
        {
           cboName.DataSource = new BindingSource(myDict, null);
           cboName.DisplayMember = "Value";            
           cboName.ValueMember = "Key";  
        }          
    }
