    var list = new List<YourType>(); // Your data source
    var groupedList = list.GroupBy(listEntry => listEntry.GroupId);
    foreach(var groupList in groupedList)
    {
       var unionList = groupList.ToList()
           .Union(list.Where(listEntry => listEntry.GroupId != groupList.Key)
           .Select(listEntry => new YourType { GroupId = groupList.Key, a = 0, b = 0, c = listEntry.c }))
    }
    
