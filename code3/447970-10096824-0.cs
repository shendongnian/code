    A relationship multiplicity constraint violation occurred: 
        An EntityReference expected at least one related object, 
        but the query returned no related objects from the data store.
    try
    {
        var test = (from h in context.Set<House>()
                    join r in context.Set<Room>()
                      on h.Room.Id equals r.Id into houseRoom
                    from joinHouseRoom in houseRoom.DefaultIfEmpty()
                    join c in context.Set<Couch>()
                      on r.Couch.Id equals c.Id into houseRoomCouch
                    from joinHouseRoomCouch in houseRoomCouch.DefaultIfEmpty()
                    select h).ToList()
                             .Select(x => x.Room.Couch.Material)
                             .ToList();
    }
    catch(SystemException se)
    {
        Console.WriteLine(se.Message);
    }
