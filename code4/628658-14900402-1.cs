    SortedDictionary<string, MyEnumType> list = new SortedDictionary<string, MyEnumType>();
    foreach (Enum e in Enum.GetValues(typeof(MyEnumType)))
    {
        list.Add(e.ToString(), (MyEnumType)e);
    }
