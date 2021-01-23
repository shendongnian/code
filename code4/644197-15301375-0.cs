    public interface ITest<T>
    {
        T GetValue();
    }
    public class Test<T, U> where T : ITest<U>
    {
        public U GetValue(T input)
        {
            return input.GetValue();
        }
    }
    public class Impl : ITest<string>
    {
        public string GetValue()
        {
            return "yay!";
        }
        public static void Example()
        {
            Test<Impl, string> val = new Test<Impl,string>();
            string result = val.GetValue(new Impl());
        }
    }
