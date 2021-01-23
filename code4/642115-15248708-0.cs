    public static City create(string postnr, string navn, City city, SqlConnection con)
    {
        DatabaseConnection.openConnection(con);
        using (var command = new SqlCommand("insert into [By] (Postnummer, Navn) values ('" + postnr + "', '" + navn + "'); select @@identity as 'identity';", con))
        {
            object ID = command.ExecuteScalar();
    
            city.id = Convert.ToInt32(ID);
            city.postnr = postnr;
            city.navn = navn;
            return city;
        }
    }
