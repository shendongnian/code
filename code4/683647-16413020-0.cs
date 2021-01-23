    SQLiteCommand insertCommand = myConnection.CreateCommand();
            insertCommand.CommandText = "insert into Records (ID, FuelType, Price, TankVolumes) values (@id, @fueltype, @price, @tankvolume)";
            insertCommand.Parameters.Add(new SQLiteParameter("@id"));
            insertCommand.Parameters.Add(new SQLiteParameter("@fueltype"));
            insertCommand.Parameters.Add(new SQLiteParameter("@price"));
            insertCommand.Parameters.Add(new SQLiteParameter("@tankvolume"));
            addSQL(insertCommand, int.Parse(SQLData[0]), SQLData[1], float.Parse(SQLData[2]), double.Parse(SQLData[3]));
 
    public static void addSQL(SQLiteCommand insertCommand, int pumpID, string fuel, float price, double volume){
             /// Now, set the values for the insert command and add two records
            insertCommand.Parameters["@id"].Value = pumpID;
            insertCommand.Parameters["@fueltype"].Value = fuel;
            insertCommand.Parameters["@price"].Value = price;
            insertCommand.Parameters["@tankvolume"].Value = volume;
            insertCommand.ExecuteNonQuery();
        }
