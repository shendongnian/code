    List<int> numbers = new List<int>();
    for (int i = 0; i < 10; i++)
    {
       numbers.Add(i+1); //adds the numbers 1 through 10
    }
    Console.WriteLine(numbers[0]); //writes out 1 - the first item
    Console.WriteLine(numbers[3]); //writes out 4 - the fourth item
    Console.WriteLine(numbers.Count); //writes out 10 - there are ten elements
    numbers.RemoveAt(0); //removes the first element of the list
    Console.WriteLine(numbers[0]); //writes out 2 - the new first item
    Console.WriteLine(numbers[3]); //writes out 5 - the new fourth item
    Console.WriteLine(numbers.Count); //writes out 9 - there are nine elements now
    numbers.RemoveAt(3); //removes the fourth element of the list
    Console.WriteLine(numbers[0]); //writes out 2 - still the first item
    Console.WriteLine(numbers[3]); //writes out 6 - the new fourth item
    Console.WriteLine(numbers.Count); //writes out 8 - there are eight elements total
