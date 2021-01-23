    while (numbers[i] != 10)
    {
        i++;
        string input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) { break; }
        numbers.Add(int.Parse(input));
        Console.WriteLine(numbers[i]);  
    }
