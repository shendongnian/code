    var ta = new TypeA();
    var allTypeCsThatSatisfyMyCondition = 
        from tb in ta.MyListOfTypeB                     // This will iterate to each item in the list
        from tc in tb.MyListOfTypeC                     // This will iterate to each item in the *sublist*
        where tc.SomeInteger > 100			// Condition could be anything; filter the results
        select tc;                                      // When you select, you tell your iterator to yield return that value to the caller.
	
    return allTypeCsThatSatisfyMyCondition.ToList();    // To list will force the LINQ to execute and iterate over all items in the lists, and add then to a list, effectively converting the returned items to a list.
