    public class Names
    {
        private static Dictionary<string, decimal> _specialCakes = new Dictionary<string,decimal>{
                    {"Cake 1", 1.00m},
                    {"Cake 2", 2.50m},
                    {"Cake 3", 4.00m}
              };
        public static Dictionary<string, decimal> SpecialCakes {
               get {return _specialCakes;}
        }
    }
