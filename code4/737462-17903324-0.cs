    public partial class SupplierInfo : Window, INotifyPropertyChanged
    {
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("InventoryItems");
            }
        }
        private string _selectedItem;
        public List<Inventory> InventoryItems
        {
            get
            {
                var FillList = from q in inventories
                  where q.InventoryName == SelectedItem
                  select q;
                return FillList.ToList();
            }
        }
        ...
    }
