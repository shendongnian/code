    int[] randomNumbers =  { 2, 3, 4, 5, 5, 2, 8, 9, 3, 7 };
    Dictionary<int, int> dictionary = new Dictionary<int, int>();
    Array.Sort(randomNumbers);
    foreach (int randomNumber in randomNumbers) {
        if (!dictionary.ContainsKey(randomNumber))
            dictionary.Add(randomNumber, 1);
        else
            dictionary[randomNumber]++;
        }
        StringBuilder sb = new StringBuilder();
        var sortedList = from pair in dictionary
                             orderby pair.Value descending
                             select pair;
        foreach (var x in sortedList) {
            for (int i = 0; i < x.Value; i++) {
                    sb.Append(x.Key+" ");
            }
        }
        Console.WriteLine(sb);
    }
