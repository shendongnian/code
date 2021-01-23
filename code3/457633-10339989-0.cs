    class ViewModel : INotifyPropertyChanged {
        class OpenDocumentCommand : ICommand {
            public bool CanExecute(object parameter) {
                return ViewModel.ItemIsSelected;
            }
            public OpenDocumentCommand(ViewModel viewModel) {
                viewModel.PropertyChanged += (s, e) => {
                    if ("ItemIsSelected" == e.PropertyName) {
                        RaiseCanExecuteChanged();
                    }
                };
            }
        }
    
        private bool _ItemIsSelected;
    
        public bool ItemIsSelected {
            get { return _ItemIsSelected; }
            set {
                if (value == _ItemIsSelected) return;
                _ItemIsSelected = value;
                RaisePropertyChanged("ItemIsSelected");
            }
        }
    
        public ICommand OpenDocument { 
            get { return new OpenDocumentCommand(this); } 
        }
    }
