    using System.Threading.Tasks;
    namespace Console
    {
        class Program
        {
            static void Main(string[] args)
            {
                Task<int> task = Task<int>.Factory.StartNew(() =>
                    {
                        return GenerateID();
                     });
                int result = task.Result;
                System.Console.WriteLine(result.ToString());
                System.Console.ReadLine();
            }
            static private int GenerateID()
            {
                return 123;
            }
        }
    }
