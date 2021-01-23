    public class Player
    {
        // Having a property called <entity>Id defines a relationship.
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
