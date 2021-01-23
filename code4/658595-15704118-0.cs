    var someEnumerator = getInt().GetEnumerator();
    while(someEnumerator.MoveNext())
    {
        int intEnumerate = someEnumerator.Current;
        Console.WriteLine(intEnumerate);
    }
