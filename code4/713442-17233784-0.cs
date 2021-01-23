	public class Hotel
	{
		public int Id { get; set; }
		public List<Room> Rooms { get; set; }
		
		public void AddRoom(Room room)
		{
			Rooms.Add(room);
		}
	}
	public class Room
	{    
		public Hotel Hotel { get; private set; }
		public int RoomId { get; set; }
		public int RoomTypeId { get; set; }
		public string Name { get; set; }        
		
		public Room(Hotel hotel)
		{
			this.Hotel = hotel;
		}
	}
