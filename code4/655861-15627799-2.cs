    <#+
    class Property
    {
        private bool output;
        private string name, type;
        public Property(bool output, string name, string type)
        {
            this.output = output;
            this.name = name;
            this.type = type;
        }
    }
    Property Input(string name, string type)
    {
        return new Property(false, name, type);
    }
    Property Output(string name, string type)
    {
        return new Property(true, name, type);
    }
    #>
