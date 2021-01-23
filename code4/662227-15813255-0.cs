    public class Vertebrae : Dictionary<string, double>
    {
        private Vertebrae() : base() { }
        private static Vertebrae _heights = new Vertebrae() {
            { "C7", 0.0 },
            { "T1", 0.0391914 },
            { "T2", 0.0785479 },
        };
        public static Vertebrae Heights { get { return _heights; } }
        public static double C7 { get { return Heights["C7"]; } }
        public static double T1 { get { return Heights["T1"]; } }
        public static double T3 { get { return Heights["T3"]; } }
        public static IEnumerable<double> All
        {
            get
            {
                return new List<double>() { C7, T1, T3 };
            }
        }
    }
