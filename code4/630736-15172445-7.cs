    var roomsOpenQuery = myEntityContext.Room.Where(t => t.fldClosed == 0);
    var roomsOpenQueryResolved = roomsOpenQuery.ToList();
    var contQuery = myEntityContext.Cont
        .Where(t => roomsOpenQueryResolved.Any(r => r.ID == t.ItemID))
        .Where(x => x.date == calcDate);
    var availableRooms =
        contQuery
            .Join(roomsOpenQueryResolved,
                    c => c.ItemID,
                    r => r.ID,
                    (c, r) => new AvailableRoom()
                                {
                                    ContPrice = c.Price,
                                    RoomPrice = r.Price,
                                    IDs = c.ItemID
                                })
            .ToList();
    //Price Adjustment etc...
