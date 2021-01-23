         using (SqlConnection cnn = new SqlConnection("connection_string_here"))  
        {
             SqlDataAdapter da = new SqlDataAdapter("SELECT id FROM personal 
    WHERE birthday IS NULL OR   birthday = ''", cnn); 
             DataSet ds = new DataSet(); 
             da.Fill(ds, "personal"); 
            
             List<string> pids = new List<string>();
             foreach(DataRow row in ds.Tables["personal"].Rows)
             {
               pids.Add(row["id"].ToString());
               // similarly you can update row objects here.
             }
            }
