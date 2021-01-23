    SortedSet<string> set = new SortedSet<string>();
    set.Add("b");
    set.Add("c");
    set.Add("a");
    Console.WriteLine(set.First()); // Display 'A'
    set.Remove(set.First()); // Remove 'A'
    Console.WriteLine(set.First()); // Display 'B'
