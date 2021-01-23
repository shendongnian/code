    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool closeTrigger;
        /// <summary>
        /// Gets or Sets if the main window should be closed
        /// </summary>
        public bool CloseTrigger
        {
            get { return this.closeTrigger; }
            set
            {
                this.closeTrigger = value;
                RaisePropertyChanged(nameof(CloseTrigger));
            }
        }
        public MainWindowViewModel()
        {
            // just setting for example, close the window
            CloseTrigger = true;
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
