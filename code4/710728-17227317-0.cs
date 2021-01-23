    public bool AreEqual(object leftValue, object rightValue)
    {
        var left = JsonConvert.SerializeObject(leftValue);
        var right = JsonConvert.SerializeObject(rightValue);
        
        return left == right;
    }
    public Difference<T> GetDifference<T>(T newItem, T oldItem)
    {
        var properties = typeof(T).GetProperties();
        
        var propertyValues = properties
            .Select(p => new { 
                p.Name, 
                LeftValue = p.GetValue(newItem), 
                RightValue = p.GetValue(oldItem) 
            });
        
        var differences = propertyValues
            .Where(p => !AreEqual(p.LeftValue, p.RightValue))
            .Select(p => p.Name)
            .ToList();
        
        return new Difference<T>
        {
            ChangedProperties = differences,
            NewItem = newItem,
            OldItem = oldItem
        };
    }
