    public class House
    {
        public House(Room room)
        {
            _rooms = new List<Room>;
            _rooms.Add(room);
        }
        private List<Room> _rooms;
        public List<Room> Rooms
        {
            get { return _rooms; }
        }
    }
    public class Room
    {
        
    }
