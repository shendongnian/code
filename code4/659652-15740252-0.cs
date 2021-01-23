    static void Insert(string fName, string lName, string age)
    {
        try
        {
            string connectionString =
                "server=JEBW1011ZAHID;" +        
                "initial catalog=employee;" + 
                "integrated security = true";             
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO [NyhedTB] ([NyhedDato], [NyhedTitel], [NyhedTekst]) " +
                    "VALUES (@NyhedDato, @NyhedTitel, @NyhedTekst)", conn))
                {
                    cmd.Parameters.AddWithValue("@NyhedDato", fName);
                    cmd.Parameters.AddWithValue("@NyhedTitel", lName);
                    cmd.Parameters.AddWithValue("@NyhedTekst", age);
                    int rows = cmd.ExecuteNonQuery();  // Inserted rows number
                }
            }
        }
        catch (SqlException ex)
        {
            //Log exception
            //Display Error message
        }
    }
