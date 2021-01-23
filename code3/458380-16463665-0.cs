    public class StringType<T> where T:class
    {
        private readonly string _str;
        protected StringType(string str)
        {
            _str = str;
        }
        public static implicit operator string(StringType<T> obj)
        {
            return obj == null ? null : obj._str;
        }
        public override string ToString()
        {
            return _str;
        }
        public override int GetHashCode()
        {
            return _str.GetHashCode();
        }
    }
    public class MyStringType : StringType<MyStringType>
    {
        protected MyStringType(string str) : base(str) { }
        public static MyStringType Parse(object obj)
        {
            var str = obj is string ? (string)obj : (obj == null ? null : obj.ToString());
            return str == null ? null : new MyStringType(str);
        }
    }
