    [WebMethod]
    public void Insert(int a)
    {
            string query = "INSERT INTO result (A) VALUES('" + a + "')";          
            YourClass obj = new YourClass();
            //Open connection here
            if (obj.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);   
                cmd.ExecuteNonQuery();       
                this.CloseConnection();
            }
            else
                throw new Exception("Problem in opening connection");
    }
 
