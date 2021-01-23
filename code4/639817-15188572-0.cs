    class NumericWrapper
    {
        public int Value { get; set; }
    }
    
    var items = new List<NumericWrapper>();
    var item = new NumericWrapper { Value = 10 };
    items.Add(item);
    
    // should be 11 after this line of code
    item.Value++;
    
