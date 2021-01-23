    // Define a class for a house
    public class House
    {
        // Constructor for the House class
        // This gets called whenever your code creates a "new House(...);"
        public House(Room room)
        {
            // Initialize the list of rooms.
            _rooms = new List<Room>;
            // Add the passed room to the list of rooms
            _rooms.Add(room);
        }
        // This a "backing field" for the property below it. It is a
        // private variable that stores information about the class.
        private List<Room> _rooms;
        // This is the property that exposes the above backing field.
        // This property only has a "get" method, which means that you can only
        // read the property value. However, you can still add rooms to the list,
        // even though that may seem like writing. The difference is that you cannot
        // assign a completely new list to the property.
        public List<Room> Rooms
        {
            get { return _rooms; }
        }
        // You can add methods to a class to perform a task.
        // The method below adds a room to the list of rooms.
        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }
    }
    public class Room
    {
        
    }
