        public ICommand SaveCanvasCommand
        {
            get
            {
                if (_saveCanvasCommand == null)
                    _saveCanvasCommand = new RelayCommand(() => { IsSaveCanvas = true; });
                return _saveCanvasCommand;
            }
        }
