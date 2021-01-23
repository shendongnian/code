        var rooms = dbt.Rooms.Where(r => r.h_id == AccID)
            .Except(prebookedRooms ?? Enumerable.Empty<T>().AsQueryable().DefualtIfEmpty(new Room(-1, -1, -1)))
            .GroupBy(p => p.RoomTypes).Select(g => new RatesViewModel
            {
                TypeName = g.Key.t_name,
                TypeID = g.Key.t_id,
                TypeCount = g.Count()
            })
            .ToList();
