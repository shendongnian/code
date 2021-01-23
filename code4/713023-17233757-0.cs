    class Location {
        public Location(float distance, float angle) {
    	Distance = distance;
            Angle = angle;
        }
        public Location(String distance, String angle) {
            Distance = Convert.ToSingle(values[0]);
            Angle = Convert.ToSingle(values[1]);
        }
        public float Angle { get; private set; }
        public float Distance { get; private set; }
    }
