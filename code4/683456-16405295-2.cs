    struct NameBool
    {
        private string name;
        private bool selected;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) return;
                name = value;
            }
        }
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected == value) return;  // this is you ignore a no change
                selected = value;
            }
        }
        public NameBool(string Name, bool Selected) { name = Name; selected = Selected;}
    }
