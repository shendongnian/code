            // Simulating load of dictionary from file
            var actorFromFile = new Dictionary<string, string>();
            actorFromFile.Add("Id", "1");
            actorFromFile.Add("Age", "37");
            actorFromFile.Add("Name", "Angelina Jolie");
            // Instantiate dynamically
            dynamic actor = ObjectFactory.CreateInstance(actorFromFile);
            // Test using properties
            Console.WriteLine("Actor.Id = " + actor.Id + 
                              " Name = " + actor.Name + 
                              " Age = " + actor.Age);
            Console.ReadLine();
