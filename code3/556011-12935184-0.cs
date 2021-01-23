    if (CommentTB.Text == "Please enter a comment.") 
    { 
        String csname = "Email Error"; 
        Type cstype = this.GetType(); 
        ClientScriptManager cs = Page.ClientScript; 
        if (!cs.IsStartupScriptRegistered(cstype, csname)) 
        { 
            String cstext = "alert('Please submit at least one comment.');"; 
            cs.RegisterStartupScript(cstype, csname, cstext, true); 
        } 
        FormMessage.Text = "Please submit at least one comment."; 
        return; 
    } 
		
    // This helps some but very little, just wanted to show an alternative to writing three statements
    string comment = CommentTB.Text.Replace("'", "''").Replace("’", "''").Replace("`", "''"); 
    //string comment = CommentTB.Text; 
    //comment = comment.Replace("'", "''"); 
    //comment = comment.Replace("’", "''"); 
    //comment = comment.Replace("`", "''"); 
 
    try 
    { 
        // No need to do string concatenation...just make it one string.
        // sql_query = "insert into peer_review_comment " + " (emp_id,  comment)" + " values(?employeeid, ?comment) "; 
        string sql_query = "insert into peer_review_comment (emp_id,  comment) values (?employeeid, ?comment) "; 
						
        string connStringName = "server=localhost;database=hourtracking;uid=username;password=password"; 
						
        // Use a "using" clause because it guarantees the connection is closed even when an exception occurs.
        using (MySqlConnection connection = new MySqlConnection(connStringName)) 
        {
            connection.Open(); 
            // Again, use a "using" clause
            using (MySqlCommand myCommand = new MySqlCommand(sql_query, connection)) 
            {
                Trace.Write("comment = ", comment); 
                myCommand.Parameters.Add(new MySqlParameter("?employeeid", ViewState["employeeid"].ToString())); 
                myCommand.Parameters.Add(new MySqlParameter("?comment", comment)); 
                myCommand.ExecuteNonQuery(); 
	
                // No need for a Close statement with "using" clause.
                //myCommand.Connection.Close(); 
            }
        } 
            
        FormMessage.Text = "\n Thank you for leaving anonymous feedback for " + employee_reviewed;
        ThankyouDiv.Visible = true; 
        FormFieldDiv.Visible = false; 
        reviewHeader.Visible = false; 
    }
    catch (Exception ex) 
    { 
        FormMessage.Text = "Error:SaveBtn_Click - " + ex.Message; 
    } 
