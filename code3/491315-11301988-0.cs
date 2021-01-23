    public class Room
    {
        public List<Wall> Walls { get; set; }
        public Room ( IEnumerable<Wall> walls )
        {
            Walls = new List<Wall>(walls);
        }
    }
    
