    int[] numbers = new int[SIZE] { 5, 5, 5, 7, 7, 7, 9, 7, 9, 9, 9, 1 };
    var dictionary = new Dictionary<int, int>();
    var numbersWithFour = new List<int>();
    foreach (var number in numbers)
    {
        if (dictionary.ContainsKey(number))
            dictionary[number]++;
        else
            dictionary.Add(number, 1);
    }
    foreach (var val in dictionary)
    {
        if (val.Value == 4)
        {
            numbersWithFour.Add(val.Key);
        }
    }
