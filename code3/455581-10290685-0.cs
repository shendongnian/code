    class Program
    {
        delegate object GetObjDelegate();
        static Dictionary<string, GetObjDelegate> Dic = new Dictionary<string, GetObjDelegate>();
            
        static void Main(string[] args)
        {
            Dic.Add("aaa", A.GetObj);
            Dic.Add("bbb", B.GetObj);
    
            object a = Dic["aaa"]();
            object b = Dic["bbb"]();
        }
    }
    
    class A
    {
        public A()
        {
        }
    
        public static A GetObj()
        {
            return new A();
        }
    }
    
    class B
    {
        public B()
        {
        }
    
        public static B GetObj()
        {
            return new B();
        }
    }
