    //Select statement
    public List< string >[] Select()
    {
        string query = "SELECT * FROM tableinfo";
    
        //Create a list to store the result
        List< string >[] list = new List< string >[3];
        list[0] = new List< string >();
        list[1] = new List< string >();
        list[2] = new List< string >();
    
        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["id"] + "");
                list[1].Add(dataReader["name"] + "");
                list[2].Add(dataReader["age"] + "");
            }
    
            //close Data Reader
            dataReader.Close();
    
            //close Connection
            this.CloseConnection();
    
            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }
