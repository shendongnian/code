    List<string> sortedList = new List<string>();
    foreach (Enum e in Enum.GetValues(typeof(YourEnumType)))
    {
        sortedList.Add(e.ToString());
    }
    sortedList.Sort();
