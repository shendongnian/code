            List<string> myCollection = new List<string>()
            {
                "John", "Alex", "Abdi", "Abdi", "Alex","Abdi"
            };
            myCollection.Sort();
            foreach (var name in myCollection.Distinct())
            {
                Console.WriteLine(name + " " + myCollection.Count(x=> x == name));
            }
