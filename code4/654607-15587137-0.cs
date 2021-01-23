    private static void Main(string[] args)
        {
            InitializeFunctions();
            string temp = Console.ReadLine();
            string[] s = temp.Split(' ');
            
            _functions[s[0]].Invoke(s[1]);
        }
        private static void InitializeFunctions()
        {
            _functions.Add("A",A);
            _functions.Add("B",B);
            _functions.Add("C",C);
        }
        private static Dictionary<string, Func> _functions = new Dictionary<string, Func>();
        public delegate void Func(string process);
        static void A(string s)
        {
            //Code Here...
        }
        static void B(string s)
        {
            //Code Here...
        }
        static void C(string s)
        {
            //Code Here...
        }
