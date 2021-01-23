    public class MyClass
    {
        public int MyNum { get; private set; }
        private MyClass() {}
    
        public static MyClass CreateInstance()
        {
            MyClass a = new MyClass();
            a.MyNum=5;
            return a;
        }
    
        public bool IsBigger(MyClass b)
        {
            return this.MyNum > b.MyNum;
        }
    
    }
