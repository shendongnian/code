      protected void btnInsert_Click(object sender, EventArgs e)
      {
    	String connectionString = ConfigurationManager.ConnectionStrings["DbConnect"].ConnectionString;
        String queryString = "";
         using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    	    foreach (RepeaterItem item in Repeater1.Items)
      	   {
    		TextBox Subject_Id = (TextBox)item.FindControl("Subject_Id");
          	TextBox Subject_Name = (TextBox)item.FindControl("Subject_Name");
          	TextBox Marks = (TextBox)item.FindControl("Marks");
    
    		queryString = "Insert into result VALUES (id='"+@Subject_Id+"',name='"+@Subject_Name+"',marks='"+@Marks+"')";
    
    		SqlCommand command = new SqlCommand(queryString, connection);
    
    		// execute the query to update the database
          	cmd.ExecuteNonQuery();
    	    }
    	}
        //call the function to load the gridview if it is lost on postback.
      }
