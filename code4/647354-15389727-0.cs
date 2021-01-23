    var itemToSetValue = collection.FirstOrDefault(c => c.Condition == condition);
    
    if(itemToSetValue != null)
         itemToSetValue.PropertyToSet = value;
        
    // Depending on what you mean, this predicate 
    // might be c => c != itemToSetValue instead.
    foreach (var otherItem in collection.Where(c => c.Condition != condition))
    {
        otherItem.PropertyToSet = otherValue;
    }
