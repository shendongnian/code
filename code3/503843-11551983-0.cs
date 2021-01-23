    public void Select(string filename)
    {
    		string query = "SELECT * FROM banners WHERE file = '"+filename+"'";
    
    		//open connection
    		if (this.OpenConnection() == true)
    		{
    				//create command and assign the query and connection from the constructor
    				MySqlCommand cmd = new MySqlCommand(query, connection);
    
    				//Get the DataReader from the comment using ExecuteReader
                                MySqlDataReader reader = cmd.ExecuteReader(); 
    				while (myReader.Read())  
    				{ 
                        //Use GetString etc depending on the column datatypes.
     					Console.WriteLine(myReader.GetInt32(0)); 
    				} 
    
    				//close connection
    				this.CloseConnection();
    		}
    }
