    public struct RouteAddedResponse {
        public int? id;
        public int status;
        public string message;
    }
    public struct BoardingZoneDetail
    {
        public string name;
        public string time;
        public string quota;
    }
    public struct DestinationZoneDetail
    {
        public string name;
    }
    public struct RouteSerial
    {
        public string name;
        public string rsn;
        public Dictionary<string, List<BoardingZoneDetail>> boardingzone;
        public Dictionary<string, List<DestinationZoneDetail>> destination;
    }
