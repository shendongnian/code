    class Room {
        private double _breadth;
        public Breadth {
            get { return _breadth; }
            set { _breadth = value; Raise("Breadth"); Raise("BreadthString"); }
        }
        private bool _isMetric;
        public bool IsMetric {
            get { return _isMetric; }
            set { _isMetric = value; Raise("IsMetric"); Raise("BreadthString"); }
        }
        public string BreathString {
            get { return Breadth.ToString( IsMetric ? "0.0" : "0.000" ); }
        }
    }
