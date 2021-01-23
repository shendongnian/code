    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string value = "test";
                Console.WriteLine(value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("End");
            Console.Read();
        }
    }
    public static class StaticExtensions
    {
        public static string ToString(this Object obj)
        {
            if (obj == null)
                return "";
            else
                return obj.GetType().FullName + obj.ToString() ;
        }
    }
