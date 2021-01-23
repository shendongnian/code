    using System.Web;
    using System.Web.Script.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dict = HttpUtility.ParseQueryString("Property1=A&Property2=B&Property3%5B0%5D%5BSubProperty1%5D=a&Property3%5B0%5D%5BSubProperty2%5D=b&Property3%5B1%5D%5BSubProperty1%5D=c&Property3%5B1%5D%5BSubProperty2%5D=d");
                var json = new JavaScriptSerializer().Serialize(
                                                         dict.Keys.Cast<string>()
                                                             .ToDictionary(k => k, k => dict[k]));
    
                Console.WriteLine(json);
                Console.ReadLine();
            }
        }
    }
