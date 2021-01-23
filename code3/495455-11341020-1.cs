    public class Room
    {
        public int RoomId { get; set; }
        [Display(Name = "Room Name")]
        public string Name { get; set; }
        public bool Disabled { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
    public class Client
    {
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public virtual Room Room { get; set; }
    }
