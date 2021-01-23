    public class Room
    {
        public virtual int Id { get; set; }
        public virtual string UniqueID { get; set; }
        public virtual int RoomID { get; set; }
        public virtual float Area { get; set; }
        public static Room Create(int roomId, int area)
        {
            Room room = new Room();
            room.UniqueID = Guid.NewGuid().ToString();
            room.RoomID = roomId;
            room.Area = area;
            return room;
        }
    }
