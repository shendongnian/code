    abstract class A
    {
        public abstract object Convert();
    }
    class B : A
    {
        public override object Convert()
        {
            return ConvertToX();
        }
        public X ConvertToX()
        {
            return new X();
        }
    }
    void SomeMethod()
    {
        A o = new B();
        var result = (X)o.Convert();
    }
