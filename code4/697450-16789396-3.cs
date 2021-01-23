            // let's use them as a key for the dictionary:
            var dictionary = new Dictionary<Mutable, string>
            {
                { key1, "John" },
                { key2, "Mary" },
                { key3, "Peter" }
            };
            // everything is ok, all of the keys are located properly:
            Console.WriteLine(dictionary[key1]);
            Console.WriteLine(dictionary[key2]);
            Console.WriteLine(dictionary[key3]);
