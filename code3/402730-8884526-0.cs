    /// <summary>
    /// Read in all rows from the Dogs1 table and store them in a List.
    /// </summary>
    static void DisplayDogs()
    {
        List<Dog> dogs = new List<Dog>();
        using (SqlConnection con = new SqlConnection(
    	ConsoleApplication1.Properties.Settings.Default.masterConnectionString))
        {
    	con.Open();
    
    	using (SqlCommand command = new SqlCommand("SELECT * FROM Dogs1", con))
    	{
    	    SqlDataReader reader = command.ExecuteReader();
    	    while (reader.Read())
    	    {
    		int weight = reader.GetInt32(0);    // Weight int
    		string name = reader.GetString(1);  // Name string
    		string breed = reader.GetString(2); // Breed string
    		dogs.Add(new Dog() { Weight = weight, Name = name, Breed = breed });
    	    }
    	}
        }
        foreach (Dog dog in dogs)
        {
    	Console.WriteLine(dog);
        }
    }
