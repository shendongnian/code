    var dictionary = sourceList.ToDictionary(x => x.Id, x => x.Name);
    foreach(var item in desitnationList) {
        if(dictionary.ContainsKey(item.Id)) {
            item.Name = dictionary[item.Id];
        }
    }
    destinationList = destinationList.Where(x => x.Name != null).ToList();
