        public ICommand SortStateCommand
        {
            get
            {
                if (_sortStateCommand == null)
                    _sortStateCommand = new RelayCommand(() =>
                        {
                            SortState++;
                            if (SortState == 3)
                                SortState = 0;
                        });
                return _sortStateCommand;
            }
        }
