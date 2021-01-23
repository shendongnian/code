    var data = new[] {
        new Row{ Name = "A", ID = 1, PreceedingID = 0},
        new Row{ Name = "B", ID = 2, PreceedingID = 3},
        new Row{ Name = "C", ID = 3, PreceedingID = 1},
        new Row{ Name = "D", ID = 4, PreceedingID = 2},
    };
    var byLastId = data.ToDictionary(x => x.PreceedingID);
    var newList = new List<Row>(data.Length);
    int lastId = 0;
    Row next;
    while (byLastId.TryGetValue(lastId, out next))
    {
        byLastId.Remove(lastId); // removal avoids infinite loops
        newList.Add(next);
        lastId = next.ID;
    }
