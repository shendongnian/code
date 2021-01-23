    public void SomeFunction()
    {
    
        string connString = "DSN=VIP_Company355";
    
        if (OpenConnection(connString))
        {
            MessageBox.Show("Connection Established");
        }
    }
    public bool OpenConnection(string connString);
    {
        try 
        {            
            OdbcConnection conn = new OdbcConnection(connstring);
  
            conn.Open();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message());
   
            return false;
        }
    }
