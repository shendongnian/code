    public class RStatic
    {
        private static int SomeNumber {get; set;}
        public static object SomeReference {get; set;}
        static RStatic()
        {
            SomeReference = new object();
            Console.WriteLine(SomeReference.GetHashCode());
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            var rs = new RStatic();
            var pi = rs.GetType().GetProperty("SomeReference",  BindingFlags.Static | BindingFlags.Public); // i have used GetProperty in my case
           
            Console.WriteLine(pi.GetValue(rs, null).GetHashCode());
    
    
        }
    }
