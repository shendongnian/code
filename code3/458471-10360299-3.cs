    char[] initZeros = Enumerable.Range(0, 100)
                                 .Select(i => '0')
                                 .ToArray();
    char[][] jaggedArrayOfCharZeros = Enumerable.Range(0, 100)
                                                .Select(i => initZeros)
                                                .ToArray();
