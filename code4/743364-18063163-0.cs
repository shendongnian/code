    public enum GuiMode {
        FourTexts,
        ThreeTexts,
        OneText,
        ThreeTextsAndImage
    }
    public class GuiSettings : INotifyPropertyChanged
    {
        public PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        private GuiMode mode = GuiMode.FourTexts;
        
        public GuiMode Mode {
            get {
                return mode;
            }
            set {
                if (mode != value) {
                    mode = value;
                    OnPropertyChanged("Mode");
                }
            }
        }
    }
