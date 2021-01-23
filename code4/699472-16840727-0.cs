    class InfoTable : Table
    {
        private string id;
        private string name;
        public override string Title
        {
            get { return name+id; }
        }
    }
