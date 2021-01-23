    public class Hotel
    {
        public int Id { get; set; }
        public Room[] Rooms { get; set; }
        public void AddRooms(int numRooms)
        {
            if(this.Rooms == null)
            { this.Rooms = new Room[numRooms]; }
        }
    
        public class Room
        {    
            public int RoomId { get; set; }
            public int RoomTypeId { get; set; }
    
            public string Name { get; set; }        
        }
    }
