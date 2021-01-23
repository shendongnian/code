    public NationalPart : ContentPart<NationalPartRecord>
    {
        public string Name {
            get { return Record.Name; }
            set { Record.Name = value; }
        }
    }
