    var matches = new List<Tuple<int, int>>();
    var array = new [] { 0, 1, 2, 3, 4, 5, 3, 2, 1, 0 };
    if (array.Length % 2 != 0)
        throw new Exception("Array must have an even amount of elements");
    for (int i = 0; i < array.Length / 2; i++)
    {
        if (array[i] == array[array.Length - 1 - i])
        {
            matches.Add(new Tuple<int, int>(i, array.Length - 1 - i));
        }
    }
    var firstMatchingIndex1 = matches[0].Item1;
    // This will be 0
    var firstMatchingIndex2 = matches[0].Item2;
    // This will be 9
