    using (SqlConnection con = new SqlConnection(connstring))
    using (SqlCommand com = new SqlCommand())
    using (SqlDataAdapter da = new SqlDataAdapter())
    {
       com.Connection = con;
       //etc..
    }
