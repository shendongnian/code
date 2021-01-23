    using (var conn = new SqlConnection(cs))
    {
        var dogs = connection.Query<Dog>("select Name, Age from dogs");
        
        foreach (Dog dog in dogs)
        {
            Console.WriteLine("{0} age {1}", dog.Name, dog.Age);
        }
    }
    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
