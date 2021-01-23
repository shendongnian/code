      // Mention size of the nvarchar column   , here i give 500 , you can use its length for @Firstname as you mention in database according to your database 
       SqlCommand command = new SqlCommand("inserting", con);
     command.CommandType = CommandType.StoredProcedure;
     command.Parameters.Add(new SqlParameter("@Firstname", SqlDbType.NVarChar,500).Value = TextBox1.Text;
   
    
