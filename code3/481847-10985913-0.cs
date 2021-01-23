    Dictionary<char, int> myLetters = new Dictionary<char, int>();
    
    
    Enumerable.Range(0,26)
              .Select( indx => (char)+('a' + indx))
              .ToList()
              .ForEach( chr => myLetters.Add( chr, 0 ));
    
    myLetters['a'] = 2;
    
    myLetters.ToList()
             .ForEach( ml => Console.WriteLine("{0} : {1}", ml.Key, ml.Value));
    
    /* Prints out
    a : 2
    b : 0
    c : 0
    ...
    z : 0
    */
