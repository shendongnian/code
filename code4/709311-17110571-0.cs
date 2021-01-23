        private List<yourClass> list;
        public List<yourClass> List
        {
            get { return list; }
            set
            {
                list = vaule;
                RaisPropertyChanged("List");
            }
        }
        private yourClass item;
        public yourClass Item
        {
            get { return item; }
            set
            {
                item = vaule;
                RaisPropertyChanged("Item");
            }
        }
