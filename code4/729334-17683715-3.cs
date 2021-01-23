    public class Radio
    {
        public delegate void StationEvent(int channel);
        private int _station;
        public int Station
        {
            get { return _station; }
            set 
            {
                _station= value;
                if(SetStation != null)
                    SetStation(_station);
            }
        }
      
        public event StationEvent SetStation;
        // etc...
    }
    public class Car
    {
        private Radio _radio = new Radio();
        public Car()
        {
            _radio.SetStation += (station) => { /* Set station was called */ };
        }
        public Radio Radio { get { return _radio; } }
    }
