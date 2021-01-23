    public class YCoordinate : Coordinates
    {
        public override List<Coordinates> GetCoordinateList() 
        {
            List<Coordinates> _list = new List<Coordinates>();
            _list.Add(new YCoordinate(1, 5000));
            _list.Add(new YCoordinate(2, 100000));
            return _list;
        }
    }
