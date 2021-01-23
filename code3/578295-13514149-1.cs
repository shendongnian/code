    var duplicates = new Dictionary<object,Queue<object>>;
    var possibleDuplicates = new Dictionary<object,object>();
    foreach(var item in original){
        if(possibleDuplicates.ContainsKey(item)){
           duplicates.Add(item, new Queue<object>{possibleDuplicates[item],item});
           possibleDuplicates.Remove(item);
        } else if(duplicates.ContainsKey(item)){
           duplicates[item].Add(item);
        } else {
           possibleDuplicates.Add(item);
        }
    }
