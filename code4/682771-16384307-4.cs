    // characters2 = created new list with Characters to be added
    foreach (var item in characters2)
    {
        Character character = item;
        // characters1 = obtained from sessions
        bool contains = characters1.Contains(character, new CharacterComparer());
        if (contains)
        {
            Console.WriteLine("Character {0} exists", character.Name);
        }
    }
