    private static IEnumerable<object> ConsumeChickens(IEnumerable<int> xList)
    {
        foreach (var x in xList)
        {
            Console.WriteLine("X: " + x);
            yield return null;
        }
    }
    private static IEnumerable<object> ConsumeGoats(IEnumerable<int> yList)
    {
        foreach (var y in yList)
        {
            Console.WriteLine("Y: " + y);
            yield return null;
        }
    }
    private static IEnumerable<int> SelectHelper(IEnumerator<AnimalCount> enumerator, int i)
    {
        bool c = i != 0 || enumerator.MoveNext();
        while (c)
        {
            if (i == 0)
            {
                yield return enumerator.Current.Chickens;
                c = enumerator.MoveNext();
            }
            else
            {
                yield return enumerator.Current.Goats;
            }
        }
    }
    private static void Main(string[] args)
    {
        var enumerator = GetAnimals().GetEnumerator();
        var chickensList = ConsumeChickens(SelectHelper(enumerator, 0));
        var goatsList = ConsumeGoats(SelectHelper(enumerator, 1));
        var temp = chickensList.Zip(goatsList, (i, i1) => (object) null);
        temp.ToList();
        Console.WriteLine("Total iterations: " + iterations);
    }
