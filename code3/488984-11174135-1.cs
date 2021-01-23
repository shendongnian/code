    class RouteStop
    {   // make setters private and init them in ctor to make it immutable
        public string Tag {get; set;} //maybe int ?
        public string Title {get; set;}
        public double Latitude {get; set;}
        public double Longitude {get; set;}
        public int ID {get; set;}
    }
