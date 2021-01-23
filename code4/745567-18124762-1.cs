        private RelayCommand _doneEditingCommand;
        public RelayCommand DoneEditingCommand
        {
            get { return _doneEditingCommand ?? (_doneEditingCommand = new RelayCommand(HandleDoneEditing, () => true)); }
            set { _doneEditingCommand = value; }
        }
        public void HandleDoneEditing()
        {
            if (CurrentHarvest_TimeSheetEntry != null)
                //Do whatever you need to do.
        }
