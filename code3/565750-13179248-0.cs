        Console.Write("enter string: ");
        string s = Console.ReadLine();
        List<char> new_array = new List<char>();
        foreach(char c in s.ToCharArray())
        {
            new_array.Add(c);
        }
        Console.WriteLine(new String(new_array.ToArray()));  
