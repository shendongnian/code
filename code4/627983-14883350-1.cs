    --From SQL Server
    CREATE TABLE Orders
    (
         Id INT IDENTITY PRIMARY KEY
        ,Amount INT NOT NULL
        ,Cost MONEY NOT NULL
        ,SaleDate DATE NOT NULL DEFAULT GETUTCDATE()
    );
    
    
    
    //From C#
    public int Insert(decimal cost, int amount)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var command = connection.CreateCommand();
            //Don't specify the SaleDate and it will insert the current time
            command.CommandText = "INSERT INTO Orders(Amount, Cost) VALUES(@Amount, @Cost); SELECT SCOPE_IDENTITY();";
            command.Parameters.AddWithValue("@Amount", amount);
            command.Parameters.AddWithValue("@Cost", cost);
    
            using(var reader = command.ExecuteReader())
            {
                if(reader.Read())
                    return Convert.ToInt32(reader[0]);
            }
        }
    
        return 0;
    }
