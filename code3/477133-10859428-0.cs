    //You closed the connection before returning the dr in the your method below:
    public static SqlDataReader ExecuteSelectCommand(SqlCommand cmd)
    {
       if (cmd == null)
       {
           throw (new ArgumentNullException("cmd"));
       }
       SqlConnection con = new SqlConnection();
       cmd.Connection = con;
       con.Open();
       SqlDataReader dr = cmd.ExecuteReader();
       con.Close();  //here your connection was already closed
       return dr ;   //this dr is disconnected
    }
