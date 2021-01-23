    IEnumerable<TypeIWant> possiblyEmptyList = list.OfType<TypeIWant>();
    if (!possiblyEmptyList.Any()) 
    {
       for (int i = 0; i < list.Count; i++)
       {
            ReplacementType item = list[i] as ReplacementType;
            if (item == null)
                continue;
    
            list[i] = ConvertToTypeIWant(item);
       }
    }
