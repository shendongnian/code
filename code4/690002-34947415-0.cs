        public static void Main(string[] args)
        {
        
          string result =   Convert.ToString(GetFactorial(5));
            Console.WriteLine(result);
        }
        
        internal static int GetFactorial(int factNumber)
        {
            int factorial =1;
            int i = factNumber;            
            while(factNumber>=1)
            {
              factorial = factNumber * factorial;
                factNumber--;
            }
           return  factorial;
            
        }
