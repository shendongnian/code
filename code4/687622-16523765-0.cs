        var anotherPerson = new AnotherPerson { Age = 30, Name = "Tony Montana", Kid = new Kid { KidAge = 10, KidName = "SomeName" } };
        var properties = typeof(AnotherPerson).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (property.PropertyType == typeof(Kid)){
                var pp = typeof(Kid).GetProperties();
                Console.WriteLine("Kid:");
                foreach (PropertyInfo p in pp)
                {
                    Console.WriteLine("\t{0} = {1}", p.Name, p.GetValue(anotherPerson.Kid, null));
                }
            }
            else
                Console.WriteLine("{0} = {1}", property.Name, property.GetValue(anotherPerson, null));
        }
