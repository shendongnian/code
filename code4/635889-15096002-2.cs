     public class ColumnListViewModel: ViewModelBase
        {
            private ObservableCollection<ColumnViewModel> _columns;
            public ObservableCollection<ColumnViewModel> Columns
            {
                get { return _columns ?? (_columns = new ObservableCollection<ColumnViewModel>()); }
            }
    
            private DelegateCommand<ColumnViewModel> _moveUpCommand;
            public DelegateCommand<ColumnViewModel> MoveUpCommand
            {
                get { return _moveUpCommand ?? (_moveUpCommand = new DelegateCommand<ColumnViewModel>(MoveUp, x => Columns.IndexOf(x) > 0)); }
            }
    
            private DelegateCommand<ColumnViewModel> _moveDownCommand;
            public DelegateCommand<ColumnViewModel> MoveDownCommand
            {
                get { return _moveDownCommand ?? (_moveDownCommand = new DelegateCommand<ColumnViewModel>(MoveDown, x => Columns.IndexOf(x) < Columns.Count)); }
            }
    
            private void MoveUp(ColumnViewModel item)
            {
                var index = Columns.IndexOf(item);
                Columns.Move(index, index - 1);
                MoveUpCommand.RaiseCanExecuteChanged();
                MoveDownCommand.RaiseCanExecuteChanged();
            }
    
            private void MoveDown(ColumnViewModel item)
            {
                var index = Columns.IndexOf(item);
                Columns.Move(index, index + 1);
                MoveUpCommand.RaiseCanExecuteChanged();
                MoveDownCommand.RaiseCanExecuteChanged();
            }
        }
    
        public class ColumnViewModel: ViewModelBase
        {
            private bool _isPrimaryKey;
            public bool IsPrimaryKey
            {
                get { return _isPrimaryKey; }
                set
                {
                    _isPrimaryKey = value;
                    NotifyPropertyChange(() => IsPrimaryKey);
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
    
            private string _name;
            public string Name
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyPropertyChange(() => Name);
                }
            }
    
            private List<SortOrder> _sortOrders;
            public List<SortOrder> SortOrders
            {
                get { return _sortOrders ?? (_sortOrders = Enum.GetValues(typeof(SortOrder)).OfType<SortOrder>().ToList()); }
            }
    
            private SortOrder _sortOrder;
            public SortOrder SortOrder
            {
                get { return _sortOrder; }
                set
                {
                    _sortOrder = value;
                    NotifyPropertyChange(() => SortOrder);
                }
            }
        }
    
        public enum SortOrder {Unsorted, Ascending, Descending}
    }
