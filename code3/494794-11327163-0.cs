    using(SqlConnection con = new SqlConnection("ConnString"))
    {
      using(SqlCommand cmd =  new SqlCommand(con))
      {
         /do some stuffs. like add parameters. 
       }
    }
