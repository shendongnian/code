    var firstQuery =
        from rooms in myEntityContext.Room.Where(t => t.fldClosed == 0)
        join conts in myEntityContext.Cont on rooms.ID equals conts.ItemID
        where conts.date == calcDate
        select new QueryResult
                    {
                        ContPrice = conts.Price,
                        RoomPrice = rooms.Price,
                        IDs = rooms.ID
                    };
    var firstQueryResult = firstQuery.ToList();
    foreach (var t in firstQueryResult)
    {
        t.RoomPrice = t.ContPrice;
    }
