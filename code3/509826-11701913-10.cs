    public class Complex : NumericClass<Complex>
    {
        static Complex()
        {
            Add = (x, y) => new Complex(x.Re + y.Re, x.Im + y.Im);
        }
        public double Re { get; private set; }
        public double Im { get; private set; }
        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }
        public override string ToString()
        {
            return String.Format("({0}, {1})", Re, Im);
        }
    }
