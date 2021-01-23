    string s = string.Join(", ", Enumerable.Range(0, 100));
    int index = 0;
    var indeces =
    Enumerable.Range(0, s.Length - 1).Where(i =>
        {
            if (s[i] == ',')
            {
                if (index < 9)
                    ++index;
                else
                {
                    index = 0;
                    return true;
                }
            }
            return false;
        }).ToList();
    Console.WriteLine(s.Substring(0, indeces[0]));
    for (int i = 0; i < indeces.Count - 1; i++)
    {
        Console.WriteLine(s.Substring(indeces[i], indeces[i + 1] - indeces[i]));
    }
