    public void SaveDataToDB(List<Animal> animals)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        DataSet dataset = new DataSet();
        string sql = "SELECT * From Guests";
        try
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(dataset, "Guests");
            // Create the InsertCommand.
            SqlCommand command = new SqlCommand(
                "INSERT INTO Guests (Name, Age, Gender, ImportantInfo) " +
                "VALUES (@Name, @Age, @Gender, @ImportantInfo)", connection);
            // Add the parameters for the InsertCommand.
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            command.Parameters.Add("@Age", SqlDbType.Int, 4, "Age");
            command.Parameters.Add("@Gender", SqlDbType.NVarChar, 6, "Gender");
            command.Parameters.Add("@ImportantInfo", SqlDbType.NVarChar, 100, "ImportantInfo");
            foreach (Animal animal in animals)
            {
                DataRow row = dataset.Tables["Guests"].NewRow();
                row["Name"] = animal.Name;
                row["Age"] = animal.Age;
                row["Gender"] = animal.Gender;
                row["Info"] = animal.ImportantInfo;
                dataset.Tables["Guests"].Rows.Add(row);
            }
            new SqlCommandBuilder(adapter);
            adapter.Update(dataset.Tables["Guests"]);
            connection.Close();
        }
        catch
        {
            throw;
        }
    }
