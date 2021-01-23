        try
        {
            con.Open();
            cmdselect.ExecuteNonQuery();
            // Check for null values
            if (cmdselect.Parameters["@OutRes"].Value != DBNull.Value)
            {
               Results = (int)cmdselect.Parameters["@OutRes"].Value;
            }
        }
        catch (SqlException ex)
        {
            lblMessage.Text = ex.Message;
        }
        catch (Exception generalEx)
        {
            // Do something with the error - Just displaying for now
            lblMessage.Text = ex.Message;
        }
        finally
        {
            cmdselect.Dispose();
            if (con != null)
            {
                con.Close();
            }
        }
