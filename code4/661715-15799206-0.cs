    class Programme
    {
        private List<Module> _modules = new List<Module>();
        public List<Module> Modules { get { return _moduleList; } }
    }
    class CGP : Programme
    {
        public CGP() :base("CGP")
        {
            Modules.Add(new Module("example 1"));
            Modules.Add(new Module("example 2"));
        }
    }
