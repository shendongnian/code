    public class Program
    {
        public string GetString(bool verbatim)
        {
            if(verbatim)
            {
                return @"this is a test";
            }
            else
            {
                return "this is a test";
            }
        }
        public static void Main(string[] args)
        {
            var verbatim = GetString(true);
            var normal = GetString(false);
            // should print 'true', if I'm not mistaken, because of string interning
            Console.WriteLine("Reference equals:" + ReferenceEquals(verbatim, normal));
            // will definitely print 'true'
            Console.WriteLine("Equals:" + verbatim.Equals(normal));
        }
    }
