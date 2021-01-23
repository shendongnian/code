        public static int Counter = 0;
        static void Main(string[] args)
        {
            TestList<int> list = new TestList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var v = list.Where(c => c == 2).ToList(); //will use movenext 4 times
            var v = list.Where(c => true).ToList();   //will also use movenext 4 times
            List<int> tmpList = new List<int>(); //And the loop in OP question
            foreach(var i in list)
            {
                tmpList.Add(i);
            }                                    //Also 4 times.
        }
