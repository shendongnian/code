        public string StartItem
        {
            get
            {
                return _startItem;
            }
            set
            {
                this.item = webDB.Items[value]; 
            }
        }
