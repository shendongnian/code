    public class ZoneModel {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool LineFault { get; set; }
        public bool Sprinkler { get; set; }
        public int Resistance { get; set; }
        public string ZoneVersion { get; set; }
        // this property will not be serialized since it is private (by default)
        List<DetectorModel> Detectors { get; set; }
    }
