    interface IMyDoer
    {
        void DoThis();
    }
    class MyIntDoer: IMyDoer
    {
        private readonly List<int> _list;
        public MyIntClass(List<int> list) { _list = list; } 
        public void DoThis() { // Do this... }
    }
    class MyStringDoer: IMyDoer
    {
        private readonly List<string> _list;
        public MyIntClass(List<string> list) { _list = list; } 
        public void DoThis() { // Do this... }
    }
