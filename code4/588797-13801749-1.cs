    class IniStructure
    {
        public short Field1;
        public int Property1 { get; set; }
        public string Property2 { get; set; }
    }
    IniStructure ini = IniLoader.Load<IniStructure>(<fileName>);
