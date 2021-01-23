    using (SqlConnection myConnection = new SqlConnection()) {
        string doThis = "select this, that from someTable where this is not null";
        SqlCommand myCommand = new SqlCommand(dothis, myConnection);
        
        try {
           myCommand.Connection.Open();
           myReader = myCommand.ExecuteReader(); //pretend "myReader" was declared earlier
           
        } catch (Exception myEx) {
             // left to your imagination, and googling.
        }
        finally {
            myCommand.Connection.Close();
        }
    }
    // do something with the results. Your's to google and figure out
