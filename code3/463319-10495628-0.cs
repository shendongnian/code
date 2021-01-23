    class FirstDeep
    {
        private ISecondDeep oa;
    
        public FirstDeep(ISecondDeep oa) 
        { 
            this.oa = oa;
        }
    
        public string AddA(string str)
        {
           return String.Concat(str, oa.SomethingToDo(str) ? "AAA" : "BBB");
        }
    }
