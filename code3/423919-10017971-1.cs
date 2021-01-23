    QueryService qs = new QueryService();
    
    private void dbConnection() 
            {            
                try
                {
                    currentSession = qs.connect("user", "password");
                }
                catch (Exception catcherror)
                {
                    MessageBox.Show(catcherror.ToString(), "Error connecting to the database");
                }
                
            }
