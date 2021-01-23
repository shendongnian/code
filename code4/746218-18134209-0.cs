    public class MyClass : ICloneable
    {
        public string s1;
        public string s2;
        public int v1;
        public MyClass()
        {
            s1 = "";
            s2 = "";
            v1 = 0;
        }
        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
