    public class Car
    {
        private Driver _driver;
        public Driver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }
    }
    public class Driver
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
    public class Vauxhall : Car
    {
    }
    public class Ford : Car
    {
    }
