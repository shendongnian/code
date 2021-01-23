    interface IFoo
    {
        void DoSomething();
        ...
    }
    class bar1 : IFoo
    {
        public void DoSomething()
        {
             this.anotherMethodBar1();
        }
        ....
    }
    class bar2 : IFoo
    {
        public void DoSomething()
        {
             this.anotherMethodBar2();
        }
        ....
    }
