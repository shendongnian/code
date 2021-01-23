    public struct Complex
    {
        public double Imaginary;
        public double Real;
        public override string ToString()
        {
            return string.Format("Complex [Real: {0}, Imaginary: {1}]", Real, Imaginary);
        }
    }
