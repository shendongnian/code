    public interface IMovable
    {
        public bool IsMoving {get; set;}
        public Point CurrentLocation {get; set;}
        public Point DestinationLocation {get; set;}
    }
