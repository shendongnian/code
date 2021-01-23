    var FirstQuery = (from rooms in myEntityContext.Room.Where(t => t.fldClosed == 0)                                    
        join Conts in myEntityContextt.Cont on rooms.ID equals Conts.ItemID
        select new
        {
            RoomPrice = Conts.fldPrice,
            IDs = rooms.ID
        }).ToList();
