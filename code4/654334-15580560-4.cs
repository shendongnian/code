    public class ConversionContext : INotifyPropertyChanged {
        private ConversionType type;
        public ConversionType Type {
            get { return type; }
            set {
                if (type != value) {
                    type = value;
                    onPropertyChanged("ConversionType");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public enum ConversionType { None, Xls, Csv, Txt }
