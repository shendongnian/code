     public class ListBoxSampleViewModel: ViewModelBase
        {
            private ObservableCollection<ListItemViewModel> _leftItems;
            public ObservableCollection<ListItemViewModel> LeftItems
            {
                get { return _leftItems ?? (_leftItems = new ObservableCollection<ListItemViewModel>()); }
            }
    
            private ObservableCollection<ListItemViewModel> _rightItems;
            public ObservableCollection<ListItemViewModel> RightItems
            {
                get { return _rightItems ?? (_rightItems = new ObservableCollection<ListItemViewModel>()); }
            }
    
            private DelegateCommand<ListItemViewModel> _moveToRightCommand;
            public DelegateCommand<ListItemViewModel> MoveToRightCommand
            {
                get { return _moveToRightCommand ?? (_moveToRightCommand = new DelegateCommand<ListItemViewModel>(MoveToRight)); }
            }
    
            private void MoveToRight(ListItemViewModel item)
            {
                if (item != null)
                {
                    LeftItems.Remove(item);
                    RightItems.Add(item);    
                }
            }
    
            private DelegateCommand<ListItemViewModel> _moveToLeftCommand;
            public DelegateCommand<ListItemViewModel> MoveToLeftCommand
            {
                get { return _moveToLeftCommand ?? (_moveToLeftCommand = new DelegateCommand<ListItemViewModel>(MoveToLeft)); }
            }
    
            private void MoveToLeft(ListItemViewModel item)
            {
                if (item != null)
                {
                    RightItems.Remove(item);
                    LeftItems.Add(item);    
                }
            }
        }
