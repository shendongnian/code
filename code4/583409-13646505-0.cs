    using (StreamWriter writer = new StreamWriter("people.txt"))
    {
        foreach (Person p in queryAllPeople)
        {
            writer.WriteLine(p);
            Console.WriteLine(p);
        }
    }
