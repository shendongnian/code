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
                    switch (value) {
                        case GuiMode.FourTexts:
                        case GuiMode.ThreeTexts:
                        case GuiMode.OneText:
                        case GuiMode.ThreeTextsAndImage:
                            mode = value;
                            OnPropertyChanged("Mode");
                            break;
                        default:
                            throw new InvalidEnumArgumentException("value", (int)value, typeof(GuiMode));
                    }
                }
            }
        }
    }
