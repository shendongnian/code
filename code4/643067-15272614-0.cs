    decimal[] vals1 = { 1M, 2.5M, 3M, 0.002M };
    decimal[] vals2 = (decimal[])vals1.Clone();
    // test with object rules
    Console.WriteLine("{0} vs {1}",
        vals1.GetHashCode(), vals2.GetHashCode()); // 2 different numbers
    Console.WriteLine(Equals(vals1, vals2)); // False
    // now test using structural-equatable rules
    IStructuralEquatable se1 = vals1, se2 = vals2;
    var comparer = EqualityComparer<decimal>.Default;
    Console.WriteLine("{0} vs {1}",
        se1.GetHashCode(comparer), se2.GetHashCode(comparer)); // 2 identical numbers
    Console.WriteLine(se1.Equals(se2, comparer)); // True
