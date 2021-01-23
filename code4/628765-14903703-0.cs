        static void Main(string[] args)
        {
            Func<List<object>, List<object>, Func<string, object>> test = Test;
        }
        private static Func<string, object> Test(List<object> objects, List<object> list)
        {
            throw new NotImplementedException();
        }
