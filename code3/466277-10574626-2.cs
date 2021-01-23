    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetValue<int>("123"));
            Console.WriteLine(GetValue<double>("123.123"));
            Console.WriteLine(GetValue<DateTime>("2001-01-01 01:01:01"));
        }
        static T GetValue<T>(string s)
        {
            var tryParse = typeof (T).GetMethod(
                "TryParse", new [] {typeof(string), typeof(T).MakeByRefType()});
            if (tryParse == null)
                throw new InvalidOperationException();
            T t = default (T);
            var parameters = new object[] {s, t};
            var success = tryParse.Invoke(null, parameters);
            if ((bool) success) t = (T)parameters[1];
            return t;
        }
    }
