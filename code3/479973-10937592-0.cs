    SortedSet<float> set = new SortedSet<float>( );
    set.Add(13.3f);
    set.Add(0.5f);
    set.Add(5.5f);
    Console.WriteLine(string.Format("Minimum Value: {0}", set.Min)); // prints 0.5
    Console.WriteLine(string.Format("Maximum Value: {0}", set.Max)); // prints 13.3
    foreach (float f in set)
    {
        Console.WriteLine(f);
    }
    // prints:
    // 0.5
    // 5.5
    // 13.3
    // using custom IComparer<float>, see implementation below
    set = new SortedSet<float>(new FloatDescComparere());
    set.Add(13.3f);
    set.Add(0.5f);
    set.Add(5.5f);
    Console.WriteLine(string.Format("Minimum Value: {0}", set.Min)); // prints 13.3
    Console.WriteLine(string.Format("Maximum Value: {0}", set.Max)); // prints 0.5
    foreach (float f in set)
    {
        Console.WriteLine(f);
    }
    // prints:
    // 13.3
    // 5.5
    // 0.5
