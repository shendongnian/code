    class Program
    {
        public static int MyToInt(string str)
        {
            double result;
            bool success = Double.TryParse(str, out result);
            if (!success)
            {
                throw new ArgumentException(
                    "Cannot parse a string into a double");
            }
    
            return Convert.ToInt32(result);     // 156
            //return (int)result;               // 155 <<
            //return (int)Math.Round(result);   // 156
        }
    
        static void Main(string[] args)
        {
            string s = "155.500";
            int value = MyToInt(s); 
        }
    }
