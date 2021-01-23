    public YOURReturnObject PopulateGridView(int sessionid)
    {
    
    SqlConnection conn = new SqlConnection("YourDBConnectionString);
    SqlCommand comm = new SqlCommand("SP_SAMPLEPROCEDURENAME", conn);
    comm.CommandType = CommandType.StoredProcedure;
    comm.Parameters.AddWithValue("@p1",sessionid);
    
    YOURReturnObject o = new YOURReturnObject();
    
    using (comm.Connection)
    {
    comm.Connection.Open();
    while (reader.Read())
    {
    //read the results into return object 
    
    }
