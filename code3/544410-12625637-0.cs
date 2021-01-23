    public class PuntoMappa
    {
        public string Lat { get; private set; }
        public string Lng { get; private set; }
        public PuntoMappa(string Lat, string Lng)
        {
            this.Lat = Lat;
            this.Lng = Lng;
        }
    }  
