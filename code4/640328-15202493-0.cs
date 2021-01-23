    public class Stuff
    {
        public Dictionary<Beep, String> _stuff { get; set; }
        public enum Beep
        {
            HeyHo,
            LetsGo
        }
        public Stuff()
        {
            _stuff = new Dictionary<Beep, string>();
            // add item
            _stuff[Beep.HeyHo] = "response 1";
            _stuff[Beep.LetsGo] = "response 2";
        }
        public string this[Beep beep]
        {
            get { return _stuff[beep]; }
        }
    }
