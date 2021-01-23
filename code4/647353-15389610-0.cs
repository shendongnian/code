    // make sure only one item matches the condition
    var singleOne = collection.Single(c => c.Condition == condition);
    singleOne.PropertyToSet = value;
    // update the rest of the items
    var theRest = collection.Where(c => c.Condition != condition);
    theRest.ToList().ForEach(c => c.PropertyToSet = otherValue);
