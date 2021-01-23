    class YCoordinate:Coordinates
    {
        public YCoordinate(int CoordinatePriority, int Coordinate) : 
            base(CoordinatePriority, Coordinate) //Call constructor of baseclass
        {
        }
    
        public override List<Coordinates> GetCoordinateList()
        {
            List<Coordinates> list = new List<Coordinates>();
            list.Add(new YCoordinate(1, 5000));
            list.Add(new YCoordinate(2, 100000));
            return list;
        }
    }
