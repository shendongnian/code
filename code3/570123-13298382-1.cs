    public class B : A  
    {
        public static A Clone()
        {
            var a = new A();
            a.SomeProperty = this.SomeProperty;
            ...etc...
            return a;
        }
    }
