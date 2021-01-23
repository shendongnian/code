    public class Complex
    {
        public int Real { get; protected set; }
        public int Imag { get; protected set; }
        public Complex(int a, int b)
        {
            Real = a; Imag = b;
        }
        public override string ToString()
        {
            return string.Format("{0} + {1}i", Real, Imag);
        }
        public string AbsoluteValue
        {
            get { return string.Format("sqrt({0}² + {1}²)", Real, Imag); }
        }
    }
