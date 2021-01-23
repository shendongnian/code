     using (SqlConnection conn = new SqlConnection(connectionString))
        {  
        try          
        {    
        //
        //
        //             
        conn.Close();
        }
        catch (Exception ex)
        {
        MessageBox.Show(ex.Message);
        }
        finally
        {
        if (conn != null) conn.Close();
        }
        }
