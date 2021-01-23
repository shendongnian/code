    public class MyView : UserControl, INotifyPropertyChanged
    {
        private List<String> devices;
        public event PropertyChangedEventHandler PropertyChanged;
 
        public List<String> Devices
        {
            get { return devices; }
            set 
            {
                devices = value;
                // add appropriate event raising pattern
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Devices"));
            }
        }
        ...
    }
