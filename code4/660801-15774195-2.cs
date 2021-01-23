    public class MovingWordModel:PropertyChangedBase
    {
        public string Text { get; set; }
        public int FontSize { get; set; }
        public string Color { get; set; }
        private double _offsetX;
        public Double OffsetX
        {
            get { return _offsetX; }
            set
            {
                _offsetX = value;
                OnPropertyChanged("OffsetX");
            }
        }
        private double _offsetY;
        public double OffsetY
        {
            get { return _offsetY; }
            set
            {
                _offsetY = value;
                OnPropertyChanged("OffsetY");
            }
        }
    }
