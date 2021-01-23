        public class Length
    {
        private double const MillimetersPerInch = 25.4;
        private double _Millimeters;
    
        public static Length FromMillimeters(double mm)
        {
             return new Length { _Millimeters = mm };
        }
    
        public static Length FromInch(double inch)
        {
             return new Length { _Millimeters = inch * MillimetersPerInch };
        }
    
        public double Inch { get { return _Millimeters / MillimetersPerInch; } } 
        public double Millimeters { get { return _Millimeters; } }
    }
