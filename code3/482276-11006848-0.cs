    public class MyProduct : IProduct {
        private double _price;
        private double _tax;
    
        public double Price {
            get { return _price; }
            set { _price = value; }
        }
    
        public double Tax {
            get { return _tax; }
            set { _tax = value; }
        }
    
        public double CalculateCost() {
            return //some complex logic here.
        }
    }
