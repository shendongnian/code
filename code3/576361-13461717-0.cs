    public class Names
    {
        private static Dictionary<string, decimal> _specialCakes = {
                    {"Cake 1", 1.00},
                    {"Cake 2", 2.50},
                    {"Cake 3", 4.00}
              };
        public static Dictionary<string, decimal> SpecialCakes {
               get {return _specialCakes;}
        }
    }
