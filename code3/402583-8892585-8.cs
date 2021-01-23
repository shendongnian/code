    public IQueryable<RoomRateWithRoomType> RoomRateForAdmin()
    {
                var query= from rate in db.BE_RoomRates 
                           join room in db.BE_Rooms
                           on rate.RoomId equals room.RoomId
                           where rate.Status!=3 && room.Status!=3
                           select new RoomRateWithRoomType()
                           {
                               RoomRate = rate,
                               RoomType = room.RoomType
                           };
                return query;
     }
