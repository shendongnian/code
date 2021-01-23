    while(dr.Read())
    {
        string firstCell = dr[0].ToString();
        string secondCell = dr[1].ToString();
        // and so on...
    }
    
    // It will be better if you close DataReader
    dr.Close();
    
