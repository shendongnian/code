     using (SqlConnection myConnection = new SqlConnection(connString))
     {
        string oString = " SELECT  * from MyList WHERE (id = @id)";
        SqlCommand oCmd = new SqlCommand(oString, myConnection);
        oCmd.Parameters.Add(new SqlParameter("@id", ID.Text));
                     
        myConnection.Open();
        string name="";
        string lastname ="";
        using (SqlDataReader oReader = oCmd.ExecuteReader())
        {
           while (oReader.Read())
           {
              name  = oReader["name"].ToString(); // replace "name" with the name of the column you want
              lastname = oReader["lastname"].ToString();
           }
        }
        myConnection.Close();
        return name + lastname;
