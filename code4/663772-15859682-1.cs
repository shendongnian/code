    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    
    namespace WpfApplication2
    {
        public class DataModel
        {
            #region Construction and Initialization
    
            public DataModel()
            {
                var elements = new[] {1, 2, 3, 4, 5};
                Items = new List<ItemsModel>
                    {
                        new ItemsModel(elements, 1),
                        new ItemsModel(elements, 2),
                        new ItemsModel(elements, 3),
                        new ItemsModel(elements, 4),
                        new ItemsModel(elements, 5)
                    };
    
                foreach (var itemsModel in Items)
                {
                    itemsModel.PropertyChanged += SelectedItemChanged;
                }
            }
    
            #endregion
    
            public List<ItemsModel> Items { get; private set; }
    
            private void SelectedItemChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "SelectedItem")
                {
                    var model = sender as ItemsModel;
                    Debug.Assert(model != null, "model != null");
                    int pos = Items.IndexOf(model) + 1;
                    Items[model.SelectedItem - 1].SelectedItem = pos;
                }
            }
        }
    
        public class ItemsModel: INotifyPropertyChanged
        {
            #region Construction and Initialization
    
            public ItemsModel(IEnumerable<int> items, int selectedItem)
            {
                Items = items;
                _selectedItem = selectedItem;
            }
    
            #endregion
    
            public int SelectedItem
            {
                get { return _selectedItem; }
                set
                {
                    if (_selectedItem != value)
                    {
                        _selectedItem = value;
                        RaisePropertyChanged("SelectedItem");
                    }
                }
            }
    
            private int _selectedItem;
    
            public IEnumerable<int> Items { get; private set; }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void RaisePropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
