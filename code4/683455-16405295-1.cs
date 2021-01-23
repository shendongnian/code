    struct NameBool
    {
        private string name = string.Empty;
        private bool selected = false;
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
                if (selected == value) return;  // this is to ignore a no change
                selected= value;
            }
        }
        public NameBool(string Name, bool Selected) 
            { name = Name; selected = Selected;}
    }
