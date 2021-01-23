    class Program
    {        
        static void Main(string[] args)
        {            
            BigInteger bInt1 = BigInteger.Parse("0");
            BigInteger bInt2 = BigInteger.Parse("-5");
            BigInteger bInt3 = BigInteger.Parse("5");
            division10(bInt1);//it is Impossible
            division10(bInt2);//it is Possible : -2
            division10(bInt3);//it is Possible : 2       
        }
        static void division10(BigInteger bInt)
        {
            double d = 10;  
            if (bInt.IsZero)
            {
                Console.WriteLine("it is Impossible");
            }
            else
            {
                Console.WriteLine("it is Possible : {0}", d / (int)bInt);
            }
        }
    }    
