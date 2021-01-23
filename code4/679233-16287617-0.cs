    public abstract class Coordinates
    {
        public int CoordinatePriority { get; set; }
        public int Coordinate { get; set; }
        protected Coordinates(int CoordinatePriority, int Coordinate)
        {
            this.CoordinatePriority = CoordinatePriority;
            this.Coordinate = Coordinate;
        }
    
        public abstract List<Coordinates> GetCoordinateList();
    
    }
