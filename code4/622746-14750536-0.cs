    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool allItemsAreChecked;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public bool AllItemsAreChecked
        {
            get
            {
                return this.allItemsAreChecked;
            }
            set
            {
                this.allItemsAreChecked = value;
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs("AllItemsAreChecked"));
                }
            }
        }
    }
