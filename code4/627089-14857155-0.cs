    using(SqlConnection con = new SqlConnection("YourConnectionString"))
    {
       string selectQuery = "Select [ID] from tbDepartment where Title = @Title";
       SqlCommand cmd = new SqlCommand(selectQuery, con);
       
       cmd.Parameters.AddWithValues("@Title", "Title_Value");
       con.Open();
       SqlDataReader reader = cmd.ExecuteReader();
       
       if(!reader.HasRows){
           string insertQuery = "Insert into tbDepartment ([Title], [Abbreviation]) " +
                                "values (@Title, @Abb)";
           cmd.CommandText = insertQuery;
           cmd.Parameters.AddWithValues("@Abb", "Abb_Value");
           cmd.ExecuteNonQuery();
       }
    
    }
