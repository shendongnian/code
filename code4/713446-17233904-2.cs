    public class Hotel
    {
        public int Id { get; set; }
        public Room[] Rooms { get; set; }
        public void AddRoom(int id, int typeID, string name)
        {
            Room room = new Room(id, typeID, name);
            this.Rooms.Add(room);
        }
    
        public class Room
        {    
            public int RoomId { get; set; }
            public int RoomTypeId { get; set; }
    
            public string Name { get; set; }        
            public Room(int id, int typeID, string name)
            {
                RoomID = id;
                RoomTypeId = typeID;
                Name = name;
            }
        }
    }
