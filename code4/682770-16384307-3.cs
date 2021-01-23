            HashSet<Character> characters1 = new HashSet<Character>(new CharacterComparer());
            characters1.Add(new Character {Name = "Alex"});
            characters1.Add(new Character { Name = "Peter" });
            characters1.Add(new Character { Name = "John" });
            HashSet<Character> characters2 = new HashSet<Character>(new CharacterComparer());
            characters2.Add(new Character { Name = "John" });
            characters2.Add(new Character { Name = "Jenny" });
            characters2.IntersectWith(characters1);
            Console.WriteLine("Existing count: " + characters2.Count);
