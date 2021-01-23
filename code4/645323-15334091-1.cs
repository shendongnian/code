    static void Main(string[] args)
    {
        BaseClass obj = new BaseClass();
        DerivedClass obj2 = new DerivedClass();
        var x = obj.Method(2); //returns 2
        var z = obj2.Method(1); //returns 2 (2*2)
        var a = ((BaseClass)obj2).Method(1); //returns 1 (base's implementation!)
    }
    class BaseClass
    {
        public int Method(int i) { return i; }
    }
    
    class DerivedClass : BaseClass
    {
        public int Method(int i) { return i * 2; }
    }
