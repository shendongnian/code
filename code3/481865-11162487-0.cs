    public void FillList<T>(DataGridView grid, string SQLCommand, List<T> list) where T : class, new()
        {
            //Load the data into the SqlDataReader
            SqlCommand dataCommand = new SqlCommand();
            dataCommand.Connection = dataConnection;
            dataCommand.CommandType = CommandType.Text;
            dataCommand.CommandText = SQLCommand;
            SqlDataReader dataReader = dataCommand.ExecuteReader();
            //Fill the list with the contents of the reader
            while (dataReader.Read())
            {
                var obj = new T();
                //Get the property information
                PropertyInfo[] properties = typeof(T).GetProperties();
                int i = 0;
                foreach(var property in properties)
                {
                    property.SetValue((T)obj, dataReader[i], null); // set the fields of T to the reader's value
                    i++;
                }
                list.Add(obj);
            }
            dataReader.Close();
            //Bind the list to the DataGridView
            grid.DataSource = list;
        }
