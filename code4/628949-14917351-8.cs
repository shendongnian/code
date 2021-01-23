    var countingActions = new List<Action>();
    var numbers = from n in Enumerable.Range(1, 5)
                  select n.ToString(CultureInfo.InvariantCulture);
    using (var enumerator = numbers.GetEnumerator())
    {
        string s;
        while (enumerator.MoveNext())
        {
            s = enumerator.Current;
            Console.WriteLine("Creating an action where s == {0}", s);
            Action action = () => Console.WriteLine("s == {0}", s);
            countingActions.Add(action);
        }
    }
