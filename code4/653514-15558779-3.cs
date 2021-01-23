    public class MyClass
    {
        public MyClass Where(Func<string, bool> function)
        {
            return this;
        }
        public List<string> Select(Func<string, string> function)
        {
            return new List<string>();
        }
    }
    MyClass myClass = new MyClass();
    var x = from m in myClass
            where !String.IsNullOrEmpty(m)
            select m;
