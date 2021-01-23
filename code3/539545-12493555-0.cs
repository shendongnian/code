        class Thing
        {
            public string Name;
        }
        static void Main(string[] args)
        {
            var things = new List<Thing>() { new Thing { Name = "Adam" } };
            var thingLocations = new List<dynamic>();
            foreach (var thing in things)
            {
                dynamic location = new ExpandoObject();
                location.Name = thing.Name;
                location.Location = "here";
                thingLocations.Add(location);
            }
            // ... later
            foreach(var thingLocation in thingLocations)
            {
                Console.WriteLine(thingLocation.Name);
                Console.WriteLine(thingLocation.Location);
            }
            
            Console.ReadLine();
        }
