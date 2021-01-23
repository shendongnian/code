    public enum ePriceType
    {
        Fixed = 1,
        Variable = 2
    }
    
    class Program
    {
        static void Main()
        {
            int priceTypeA = 2;
            ePriceType priceTypeB = (ePriceType)priceTypeA;
            if (priceTypeB == ePriceType.Variable)
            {
                Console.WriteLine("Variable");
            }
        }
    }
