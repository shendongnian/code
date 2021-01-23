    public DataTable GetData(string SQL)
    {
         //SqlCommand cmd = new SqlCommand(SQL, cn);
         SqlDataAdapter da = new SqlDataAdapter(SQL,cn);
         DataTable dt = new DataTable();
         da.Fill(dt);
         return dt;
    } 
