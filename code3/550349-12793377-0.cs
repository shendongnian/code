    public class Model : CommonBase
    {
        public Employee empdetails { get; set; }
    }
    public class Employee : CommonBase
    {
        private string _fname;
        public string fname 
        {
            get
            {
                return _fname;
            }
            set
            {
                _fname = value;
                OnPropertyChanged("fname");
            }
        }
        public string lname { get; set; }
        private Enum _gender;
        public Enum gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged("gender");
            }
        }
    }
    public enum gender
    {
        Male,
        Female
    }
