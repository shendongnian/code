    public void run_runcommand(string query)   
    {   
        try   
        {   
            con.Open();   
            SqlCommand cmd1 = new SqlCommand(query, con);   
            cmd1.ExecuteNonQuery();    
            con.Close();    
        }    
        catch (Exception ex)
        {
           throw ex; //TODO: Please log it or remove the catch
        }
        finally
        {
           con.close();
        }
    }
    
    try       
    {           
        string query="my query";           
        db.run_runcommand(query);          
    }         
    catch(Exception ex)            
    {         
        MessageBox.Show(ex.Message);              
    }   
    finally
    {
       con.close();
    }
