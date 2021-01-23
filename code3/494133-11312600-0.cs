    class Program
    {
        static void Main(string[] args)
        {
            var result = Method1("Test");
        }
    
       static string Method1(string input)
       {
           return string.Format("I got this input: {0}", input);
       }
    }
