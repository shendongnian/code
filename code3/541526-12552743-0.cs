        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(5);
        numbers.Add(7);
        numbers.Add(13);
        numbers.Add(4);
        // And so on
        Console.Write("Numbers in increasing order: ");
        foreach (int number in numbers.OrderBy(x => x))
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
