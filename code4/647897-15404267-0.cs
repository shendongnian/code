        x int = 0;
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["username"] + "");
                list[1].Add(dataReader["password"] + ""); 
                x++;
            }
            //close Data Reader
            dataReader.Close();
            //close Connection
            this.CloseConnection();
            //return list to be displayed
            return x;
        }
