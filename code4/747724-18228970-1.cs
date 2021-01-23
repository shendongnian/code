    namespace ConsoleApplication1
    {
        using System.Configuration;
        public class Program
        {
            static void Main(string[] args)
            {
                var connectionstring = ConfigurationManager.ConnectionStrings["TheFriendlyNameOfMyConnection"].ConnectionString;
            }
        }
    }
