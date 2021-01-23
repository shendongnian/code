    public class GridItem: PropertyChangedBase
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private int? _pathIndex;
        public int? PathIndex
        {
            get { return _pathIndex; }
            set
            {
                _pathIndex = value;
                OnPropertyChanged("PathIndex");
            }
        }
    }
