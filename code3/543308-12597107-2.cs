    string query =  "INSERT INTO book (title, isbn, authorID)
    				SELECT @title as title,
    					   @isbn AS isbn,
    					   id  as authorID
    				FROM author 
    				WHERE first_name = @author";
    
    using (MySqlConnection conn = new MySqlConnection("connectionstringHere"))
    {
    	using (MySqlCommand comm = new MySqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandType = CommandType.Text;
    		comm.CommandText = query;
    		comm.Parameters.AddWithValue("@title", BookTitle.Text.ToString());
    		comm.Parameters.AddWithValue("@isbn", BookIsbn.Text.ToString());
    		comm.Parameters.AddWithValue("@author", BookAuthor.Text.ToString());
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery;
    		}
    		catch (MySqlException ex)
    		{
    			// error here
    		}
    		finally
    		{
    			conn.Close();
    		}
    	}
    }
