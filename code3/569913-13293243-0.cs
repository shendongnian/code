    public class Booking
    {
      ...
      public int RoomId { get; set; }
      public virtual Room Room { get; set; } // Needs to be virtual
      ...
    }
