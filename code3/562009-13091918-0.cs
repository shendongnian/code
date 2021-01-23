    class Cases
    {
        private  static readonly Dictionary<int, int>
            List = new Dictionary<int, int>
            {
                {9, 5},
                {3, 2},
                {7, 12},
                {4, 10}
            }; 
        public static int GetCaseValue (int v)
        {
            int result = 0;
            return List.TryGetValue(v, out result) ? result : v;
        }
    }
    class Program
    {
        public static void Main()
        { 
            var test = Cases.GetCaseValue(4);
            test = Cases.GetCaseValue(12);
        }
    }
