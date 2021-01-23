    int[][] ints1 = { new int[] { 3, 4 } };
    int[][] ints2 = { new int[] { 3, 4 } };
    Console.WriteLine(StructuralComparisons.
                              StructuralEqualityComparer.Equals(ints1, ints2));
    Console.WriteLine(ints1.SequenceEqual(ints2));
