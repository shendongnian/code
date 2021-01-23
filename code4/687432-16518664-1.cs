    class UniqueSystem
    {
        public int System { get; set; }
        public string Label { get; set; }
        public List<uniqueSubsystem> SubSystems { get; set; }
    }
    class uniqueSubsystem
    {
        public int subsystem { get; set; }
        public string Label { get; set; }
        public List<uniqueUnit> Units { get; set; }
    }
    class uniqueUnit
    {
        public int unit { get; set; }
        public string label { get; set; }
    }
