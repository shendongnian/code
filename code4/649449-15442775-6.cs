    var list = Enumerable.Range(1, n)
                         .Select(i => (BaseType) new DerivedType {
                                     x = "x" + i,
                                     y = "y" + i,
                                     z = "z" + i;
                                 })
                         .ToList();
