    public class Plc : INotifyPropertyChanged {
        private static Plc _instance;
        private Plc() { } // constructor should be private
    
        public static Plc Instance
        {
            get
            {
                if (_instance == null)                
                    _instance = new Plc();
                
                return _instance;
            } // you don't need setter
        }  
    
        private string _plcIp; // instance field instead of static property
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
