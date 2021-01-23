    var iter = yourData.GetEnumerator();
    if(iter.MoveNext()) {
        Console.WriteLine(iter.Current.Name); // first record of, say, 20
    }
    // and don't dispose the iterator == bad
