        public ObservableCollection<MyViewModel> MyItems { get; set; } //Binding to ItemsSource
        private ICommand _selectCommand;
        public ICommand SelectCommand
        {
            get { return _selectCommand ?? (_selectCommand = new DelegateCommand<MyViewModel>(DoSelect)); }
        }
        private void DoSelect(MyViewModel myViewModel)
        {
            foreach(var item in MyItems)
                if (item != myViewModel)
                {
                    item.IsSelected = false;
                    item.IsEnabled = false;
                }
        }
        private ICommand _unselectCommand;
        public ICommand UnselectCommand
        {
            get { return _unselectCommand ?? (_unselectCommand = new DelegateCommand<MyViewModel>(DoUnselect)); }
        }
        private void DoUnselect(MyViewModel myViewModel)
        {
            foreach (var item in MyItems)
                if (item != myViewModel)
                {
                    item.IsEnabled = true;
                }
        }
