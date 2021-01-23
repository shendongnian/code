    public void fgh()
     {
        //write down your database code such as
        using(con=new SqlConnection(your connection string))
        { 
          cnn=new SqlCommand( your sql command);
          cnn.Connection=con;
          using(ds=new Dataset())
            {
              con.Open();
              da.Fill(ds);
           }
      }
    }
