    public class ListViewModel: ViewModelBase
        {
            private ObservableCollection<Selectable<string>> _items;
            public ObservableCollection<Selectable<string>> Items
            {
                get { return _items ?? (_items = new ObservableCollection<Selectable<string>>()); }
            }
    
            private ObservableCollection<string> _selectedItems;
            public ObservableCollection<string> SelectedItems
            {
                get { return _selectedItems ?? (_selectedItems = new ObservableCollection<string>()); }
            }
    
            private DelegateCommand _copyCommand;
            public DelegateCommand CopyCommand
            {
                get { return _copyCommand ?? (_copyCommand = new DelegateCommand(Copy)); }
            }
    
            private void Copy()
            {
                SelectedItems.Clear();
                Items.Where(x => x.IsSelected).Select(x => x.Value).ToList().ForEach(SelectedItems.Add);
            }
    
            public ListViewModel()
            {
                Enumerable.Range(1, 100).Select(x => new Selectable<string>("Item" + x.ToString())).ToList().ForEach(x => Items.Add(x));
            }
        }
    
        public class Selectable<T>: ViewModelBase
        {
            private T _value;
            public T Value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    NotifyPropertyChange(() => Value);
                }
            }
    
            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    _isSelected = value;
                    NotifyPropertyChange(() => IsSelected);
                }
            }
    
            public Selectable(T value)
            {
                Value = value;
            }
    
            public Selectable(T value, bool isSelected): this(value)
            {
                IsSelected = isSelected;
            }
    
            public override string ToString()
            {
                return Value != null ? Value.ToString() : string.Empty;
            }
    
        }
