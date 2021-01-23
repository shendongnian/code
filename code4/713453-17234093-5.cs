    public class Hotel
    {
        private readonly int id;
        private readonly IList<Room> rooms;
        public Hotel(int id; IEnumerable<Room> rooms)
        {
            this.id = id;
            this.rooms = rooms.ToList();
        }
        public int Id
        {
            get { return this.id; }
        }
        public IEnumerable<Room> Rooms
        {
            get { return this.rooms; }
        }
        public class Room
        {
            private readonly int id;
            private readonly RoomType type;
            private readonly string name;
            public Room(int id, RoomType type, string name)
            {
            }
            public int Id
            { 
               get { return this.id; }
            }
            public RoomType Type
            {
                get { return this.type; }
            }
            public string Name
            {
               get { return this.name; }
            }
        }
        public enum RoomType
        {
            // Valid Room Types Here,
            // ...
        }
    }
