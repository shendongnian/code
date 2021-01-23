    class Program
    {
        /// <summary>
        /// Format a value using engineering notation.
        /// </summary>
        /// <example>
        ///     Format("S4",-12345678.9) = "-12.34e-6"
        ///     with 4 significant digits
        /// </example>
        /// <arg name="format">The format specifier</arg>
        /// <arg name="value">The value</arg>
        /// <returns>A string representing the value formatted according to the format specifier</returns>
        public static string Format(string format, double value)
        {
            if(format.StartsWith("S"))
            {
                string dg=format.Substring(1);
                int significant_digits;
                int.TryParse(dg, out significant_digits);
                if(significant_digits==0) significant_digits=4;
                int sign;
                double amt;
                int exponent;
                SplitEngineeringParts(value, out sign, out amt, out exponent);
                return ComposeEngrFormat(significant_digits, sign, amt, exponent);
            }
            else
            {
                return value.ToString(format);
            }
        }
        static void SplitEngineeringParts(double value,
                    out int sign,
                    out double new_value,
                    out int exponent)
        {
            sign=Math.Sign(value);
            value=Math.Abs(value);
            if(value>0.0)
            {
                if(value>1.0)
                {
                    exponent=(int)(Math.Floor(Math.Log10(value)/3.0)*3.0);
                }
                else
                {
                    exponent=(int)(Math.Ceiling(Math.Log10(value)/3.0)*3.0);
                }
            }
            else
            {
                exponent=0;
            }
            new_value=value*Math.Pow(10.0, -exponent);
            if(new_value>=1e3)
            {
                new_value/=1e3;
                exponent+=3;
            }
            if(new_value<=1e-3&&new_value>0)
            {
                new_value*=1e3;
                exponent-=3;
            }
        }
        static string ComposeEngrFormat(int significant_digits, int sign, double v, int exponent)
        {
            int expsign=Math.Sign(exponent);
            exponent=Math.Abs(exponent);
            int digits=v>0?(int)Math.Log10(v)+1:0;
            int decimals=Math.Max(significant_digits-digits, 0);
            double round=Math.Pow(10, -decimals);
            digits=v>0?(int)Math.Log10(v+0.5*round)+1:0;
            decimals=Math.Max(significant_digits-digits, 0);
            string t;
            string f="0:F";
            if(exponent==0)
            {
                t=string.Format("{"+f+decimals+"}", sign*v);
            }
            else
            {
                t=string.Format("{"+f+decimals+"}e{1}", sign*v, expsign*exponent);
            }
            return t;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\t1.0      = {0}", Format("S3", 1.0));
            Console.WriteLine("\t0.1      = {0}", Format("S3", 0.1));
            Console.WriteLine("\t0.01     = {0}", Format("S3", 0.01));
            Console.WriteLine("\t0.001    = {0}", Format("S3", 0.001));
            Console.WriteLine("\t0.0001   = {0}", Format("S3", 0.0001));
            Console.WriteLine("\t0.00001  = {0}", Format("S3", 0.00001));
            Console.WriteLine("\t0.000001 = {0}", Format("S3", 0.000001));
        }
    }
