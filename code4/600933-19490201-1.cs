    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool isGuiEnabled;
        /// <summary>
        /// True to enable buttons, false to disable buttons.
        /// </summary>
        public bool IsGuiEnabled 
        {
            get
            {
                return isGuiEnabled;
            }
            set
            {
                isGuiEnabled = value;
                OnPropertyChanged("IsGuiEnabled");
            }
        }
        public ICommand DeviceCommand
        {
            get
            {
                return new RelayCommand(this.CallExternalDevice, this.IsGuiEnabled);
            }
        }
        private async void CallExternalDevice(object obj)
        {
            IsGuiEnabled = false;
            try
            {
                await Task.Factory.StartNew(() => Thread.Sleep(3000));
            }
            finally
            {
                IsGuiEnabled = true; 
            }
        }
    }
