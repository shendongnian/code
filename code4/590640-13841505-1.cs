    class RoomObject
    {
        public RoomObject(RoomObject roomObject)
        {
        //Copy room object properties
        }
    }
    
    class Bed : RoomObject
    {
        public Bed(Bed bed) : base(bed)
        {
        //Copy Bed properties
        }
    }
