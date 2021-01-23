    public class ViewModel
    {
        private RelayCommand _okCommand;
        public RelayCommand OkCommand
        {
            get
            {
                return _okCommand
                    ?? (_okCommand = new RelayCommand(
                                          async _ =>
                                          {
                                              await new MessageDialog("OkCommand").ShowAsync();
                                          }));
            }
        }
    }
