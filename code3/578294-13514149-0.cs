    var duplicates = new Dictionary<object,Queue<object>>;
    var possibleDuplicates = new Dictionary<object,object>();
    foreach()var item in original){
        if(possibleDuplicates.ContainKey(item)){
           duplicates.Add(item, new Queue<object>{possibleDuplicates[item],item});
           possibleDuplicates.REmove(item);
        } else if(duplicates.ContainKey(item)){
           duplicates[item].Add(item);
        } else {
           possibleDuplicates.Add(item);
        }
    }
