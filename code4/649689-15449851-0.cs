    [Serializable()]
    public class Camera
    {
        public string name;
        public int index;
        public double distance;
        public List<string> CameraList { get; set; }
        private GMarkerGoogle _marker;
        [XmlIgnore()]
        public GMarkerGoogle Marker
        {
            set
            {
                _marker = value;
                MarkerPosition = _marker.position;
                MarkerRotation = _marker.rotation;
            }
            get
            {
                if (_marker == null)
                {
                    _marker = new GMarkerGoogle(MarkerPosition, MarkerRotation);
                }
                return _marker;
            }
        }
        public double MarkerPosition { get; set; }
        public double MarkerRotation { get; set; }
        public Camera()
        {
        }
    }
