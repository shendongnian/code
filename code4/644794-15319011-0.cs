    public static class ObjectArrayExtensions
    {
        public static string[] ToStringArray(this object[] array)
        {
            var nonNull = array.Where(e => e != null).ToArray();
            string[] result = new string[nonNull.Count()];
            for (int i = 0; i < nonNull.Count(); i++)
            {
                result[i] = nonNull[i].ToString();
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            object[] array = new object[] { 10, "hello", 5, "world", null };
            var stringArray = array.ToStringArray();
        }
    }
