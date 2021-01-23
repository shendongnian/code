    var objectList = new List<DataObject>();
    var lastob = objectList.Last();
    objectList.Remove(lastob);
    var newList = new List<DataObject>();
    newList.Add(lastob);
    newList.AddRange(objectList.OrderBy(o => o.Id).ToList());
