        SqlConnection sqlConnection  = new SqlConnection(s);
        	
        string sqlIns = "INSERT INTO address(name,age,city) VALUES (@na,@ag,@ci)";
        sqlConnection.Open();
        try
        {
         SqlCommand cmdIns = new SqlCommand(sqlIns, sqlConnection.Connection);
         cmdIns.Parameters.Add("@na", na);
         cmdIns.Parameters.Add("@ag", ag);
         cmdIns.Parameters.Add("@ci", ci);
         cmdIns.ExecuteNonQuery();
         
        }
        catch(Exception ex)
        {
        throw new Exception(ex.ToString(), ex);
        }
        finally
        {
        sqlConnection.Close();
        }
