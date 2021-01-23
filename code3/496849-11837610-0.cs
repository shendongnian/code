        using (var fdb = new FALDbContext())
        {
            foreach (var member in fdb.Members)
            {
                var places = fdb.Entry(member)
                                .Collection(m => m.Places)
                                .Query()
                                .Where(p => p.PlaceName.StartsWith("L"))
                                .Select(p => p.PlaceName);
                foreach (var place in places)
                {
                    Console.WriteLine(place);
                }
            }
        }
