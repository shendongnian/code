            var dictionary = new Dictionary<string, string>
            {
                { "1", "Jonh" },
                { "2", "Mary" },
                { "3", "Peter" },
            };
            Console.WriteLine(dictionary["1"]); // outputs "John"
            // this is the indexer metadata;
            // indexer properties are named with the "Item"
            var prop = dictionary.GetType().GetProperty("Item");
            // the 1st argument - dictionary instance,
            // the second - new value
            // the third - array of indexers with single item, 
            // because Dictionary<TKey, TValue>.Item[TKey] accepts only one parameter
            prop.SetValue(dictionary, "James", new[] { "1" });
            Console.WriteLine(dictionary["1"]); // outputs "James"
