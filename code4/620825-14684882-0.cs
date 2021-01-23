    public class Plc : INotifyPropertyChanged {
        private static Plc instance;
        private plc() { } // constructor should be private
    
        public static Plc Instance
        {
            get
            {
                if (instance == null)                
                    instance = new Plc();
                
                return instance;
            } // you don't need setter
        }  
    
        private string _plcIp; // field instead of property
        public string PlcIp
        {
            get { return _plcIp; }
            set
            {
                if (_plcIp == value)
                    return; // check if value changed
                _plcIp = value; // change value
                OnPropertyChanged(); // raise event               
            }    
        }    
        // ...
    }
