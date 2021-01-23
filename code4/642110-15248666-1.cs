    public static City Create(string postnr, string navn, SqlConnection con)
    {
        DatabaseConnection.openConnection(con);
        using (var command = new SqlCommand
             ("insert into [By] (Postnummer, Navn) values (@postnr, @navn); "+
              "select @@identity as 'identity';", con))
        {
            command.Parameters.Add("@postnr", SqlDbType.NVarChar").Value = postnr;
            command.Parameters.Add("@navn", SqlDbType.NVarChar").Value = navn;
            object ID = command.ExecuteScalar();
    
            City = new City();
            city.id = Convert.ToInt32(ID);
            city.postnr = postnr;
            city.navn = navn;
            return city;
        }
    }
