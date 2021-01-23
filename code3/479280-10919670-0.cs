    class MainViewModel : Bindablebase {
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        
        private ItemViewModel _selectedItem;
        public ItemViewModel SelectedItem {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value, "SelectedItem"); }
        }
    }
    class ItemViewModel : BindableBase {
        public ItemViewModel (string name) {
            Name = name;
            Items = new ObservableCollection<string>();
        }
        
        public string Name { get; private set; }
        
        public ObservableCollection<string> Values { get; private set; }
        
        private string _selectedValue;
        public string SelectedValue {
            get { return _selectedValue; }
            set { SetProperty(ref _selectedValue, value, "SelectedValue"); }
        }
    }
