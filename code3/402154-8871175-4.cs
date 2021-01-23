    public class ViewModel : INotifyPropertyChanged
    {
        private bool imagesVisibility;
        private bool isTextBoxEnabled;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool ImagesVisibility
        {
            get { return this.imagesVisibility; }
            set
            {
                this.imagesVisibility = value;
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs("ImagesVisibility"));
            }
        }
 
        public bool IsTextBoxEnabled
        {
            // ... similar as with ImagesVisibility property implementation
        }
    }
