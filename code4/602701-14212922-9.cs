        private ICommand showDCNoteCommand;
        public ICommand ShowDCNoteCommand
        {
            get
            {
                if (this.showDCNoteCommand == null)
                {
                    this.showDCNoteCommand = new RelayCommand(this.DCNoteFormExecute, this.DCNoteFormCanExecute);
                }
                return this.showDCNoteCommand;
            }
        }
        private bool DCNoteFormCanExecute()
        {
            return !string.IsNullOrEmpty(DCNotes);
            
        }
        private void DCNoteFormExecute()
        {
            DCNoteMethod(); //This a method that changed the text
        }
