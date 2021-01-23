    IList nonGenericList = uncastedFieldOfBValue as IList;
    IEnumerable<dynamic> dynamicEnumerable = nonGenericList.Cast<dynamic>();
    foreach (dynamic obj in dynamicEnumerable)
    {
        // work with your objects here
    }
