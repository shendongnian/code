    string qry="select Column1,Column2,Column3 from YourSchema.YourTable";
    using (SQLConnection myConnection=new SQLConnection(Web.ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
    {
        using(SQLCommand myCommand=new SQLCommand(qry,myConnection))
        {
            try 
            {
                 myConnection.Open(); 
                 using(SQLDataReader myReader= myCommand.ExecuteReader())
                 {
                     if(myReader.HasRows)
                     {
                          while(myReader.Read())
                          {
                             Label1.Text= myReader[0].ToString();
                             Label2.Text= myReader[1].ToString();
                             Label3.Text= myReader[2].ToString();
                          }
                     }
                 }
            }
            catch(SQLException ex)
            {
                 // Log exception
                 throw ex;
            }  
            finally
            {
                if(myConnection!=null)
                    myConnection.Close();
            }
        }
    }
