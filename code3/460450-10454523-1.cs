    public System.Collections.IEnumerable GetItems(List<string> lst)
    {
        for (int Index = 0; Index < lst.Count; Index++)
        {
            //Some condition here to filter the list
            if (lst[Index].StartsWith("A"))
            {
                yield return lst[Index];
            }
        }
    }
