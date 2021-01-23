        static void Main(string[] args)
        {
            Complex RA = new Complex(25, 20);
            Console.WriteLine("{0} + i{1}", RA.Real, RA.Imaginary);
   
            double r, q, z;
            r = Math.Sqrt((RA.Real * RA.Real) + (RA.Imaginary * RA.Imaginary));
            q = Math.Atan(RA.Imaginary/RA.Real);
            z = (q * (180/Math.PI));
            Console.WriteLine("{0} < {1}", r, z);
            Console.ReadLine();
        }
