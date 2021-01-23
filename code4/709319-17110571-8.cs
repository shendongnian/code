    private yourClass item;
        public yourClass Item
        {
            get { return item; }
            set
            {
                item = value;
                RaisPropertyChanged("Item");
    
                SelectedItems = List.Where(listItem => listItem.IsSelected).ToList();
            }
        }
    
        private List<yourClass> selectedItems;
        public List<yourClass> SelectedItems
        {
            get { return selectedItems; }
            set
            {
                selectedItems = value;
                RaisPropertyChanged("SelectedItems");
            }
        }
