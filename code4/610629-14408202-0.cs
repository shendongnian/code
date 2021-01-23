    struct AStruct
    {
        public string a;
        public int b;
    
        static void Main()
        {
            var structs = new AStruct[10];
    
            foreach (var x in structs) {
                Console.WriteLine(x);
            }
        }
    }
