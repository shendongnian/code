    [DataContract]
    public class GpsPosition
    {
        private float _lat;
        private float _lon;
        private bool _latWasSet;
        private bool _lonWasSet;
        
        public GpsPosition(float lat, float lon)
        {
            _lat = lat;
            _lon = lon;
        }
        
        [DataMember]
        public float lat
        {
            get { return _lat; }
            private set
            {
                _lat = value;
                _latWasSet = true;
            }
        }
        
        [DataMember]
        public float lon
        {
            get { return _lon; }
            private set
            {
                _lon = value;
                _lonWasSet = true;
            }
        }
        
        [OnDeserialized]
        void OnDeserialized(StreamingContext ctx)
        {
            if (!_latWasSet || _!lonWasSet ||
                _lat < -90 || _lat > 90 ||
                _lon < -180 || _lon > 180)
            {
                throw new InvalidOperationException("Required property is missing");
            }
        }
    }
