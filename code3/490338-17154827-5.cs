    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }
        
        void Start()
        {
            string[] items = new string[5];
            items[0] = "A";
            items[1] = "B";
            items[2] = "C";
            items[3] = "D";
            items[4] = "E";
            new PermutationFinder<string>().Evaluate(items, Evaluate);
            Console.ReadLine();
        }
        public bool Evaluate(string[] items)
        {
            Console.WriteLine(string.Format("{0},{1},{2},{3},{4}", items[0], items[1], items[2], items[3], items[4]));
            bool someCondition = false;
            if (someCondition)
                return true;  // Tell the permutation finder to stop.
            return false;
        }
    }
