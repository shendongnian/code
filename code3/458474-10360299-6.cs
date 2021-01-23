    char[] initZeros = Enumerable.Range(0, 100)
                                 .Select(i => '0')
                                 .ToArray();
    char[][] jaggedOfCharZeros = Enumerable.Range(0, 100)
                                           .Select(i => (char[])initZeros.Clone())
                                           .ToArray();
