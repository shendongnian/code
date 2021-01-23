    typeof(int).Assembly.GetTypes()
    					.Where(type => type.IsGenericType)
    					.Where(type=>type.GetGenericArguments().Any(IsCovariant))
    					.Select(type => type.Name)
    					.Dump();
    //Converter`2 
    //IEnumerator`1 
    //IEnumerable`1 
    //IReadOnlyCollection`1 
    //IReadOnlyList`1 
    //IObservable`1 
    //Indexer_Get_Delegate`1 
    //GetEnumerator_Delegate`1 
