    var list1 = new List<bool>(){true,false};
    var list2 = new List<int>(){1,2};
    var typecollection = condition1 ? list1.Cast<IConvertible>() : list2.Cast<IConvertible>();
    foreach (IConvertible convertible in typecollection)
    {
        //we now know they have a common interface so we can call a common method
        Debug.WriteLine(convertible.ToString());
    }
