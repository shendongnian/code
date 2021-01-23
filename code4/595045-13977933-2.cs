    IEnumerable<Item> SomeOperationFunction(IEnumerable<Item> target)
    {
       return target
         .Select((item, index) => new { Item = item, Index = index })
         .Where(i => i.Index != 3);
    }
