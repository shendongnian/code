    public class MyDictionary
    {
        List<object> values;
        public MyDictionary()
        {
            values = new List<object>();
        }
        public T GetValue<T>()
        {
            return values.OfType<T>().FirstOrDefault();
        }
        public bool Add<T>(T value)
        {
            if (values.OfType<T>().Any())
                return false;
            else
            {
                values.Add(value);
                return true;
            }
        }
    }
