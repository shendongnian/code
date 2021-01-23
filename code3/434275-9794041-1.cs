    // ViewModelBase and Set() are from MVVM Light Toolkit
    public class ComboBoxWithObsoleteItemsViewModel : ViewModelBase
    {
        private readonly string _originalCurrency;
        private ObservableCollection<string> _items;
        private readonly bool _removeOriginalWhenNotSelected;
        private string _selectedItem;
        public ComboBoxWithObsoleteItemsViewModel()
        {
            // This value might be passed in to the VM as a parameter
            // or obtained from a data service
            _originalCurrency = "AUD";
            // This list is hard-coded or obtained from your data service
            var collection = new ObservableCollection<string> {"USD", "CAD", "EUR"};
            // If the value to display isn't in the list, then add it
            if (!collection.Contains(_originalCurrency))
            {
                // Record the fact that we may need to remove this
                // value from the list later.
                _removeOriginalWhenNotSelected = true;
                collection.Add(_originalCurrency);
            }
            Items = collection;
            SelectedItem = _originalCurrency;
        }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                // Remove the original value from the list if necessary
                if(_removeOriginalWhenNotSelected && value != _originalCurrency)
                {
                    Items.Remove(_originalCurrency);
                }
                Set(()=>SelectedItem, ref _selectedItem, value);
            }
        }
        public ObservableCollection<string> Items
        {
            get { return _items; }
            private set { Set(()=>Items, ref _items, value); }
        }
    }
