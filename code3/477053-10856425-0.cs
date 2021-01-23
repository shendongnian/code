        int[] a = { 5, 2, 3 }; 
        int[] b = { 4, 1, 2 };
        string[] c = { "John", "Peter", "Max" };
        Array.Sort(b.ToArray(), c);
        Array.Sort(b.ToArray(), a);
        Array.Sort(b);
        Console.WriteLine(string.Join(", ", a));
        Console.WriteLine(string.Join(", ", b));
        Console.WriteLine(string.Join(", ", c));
