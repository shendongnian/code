    class Program
    {
        static void Main(string[] args)
        {
            var test = new { Text = "test", Slab = "slab"};
            Console.WriteLine(test.Text); //outputs test
            Console.WriteLine(TestMethod(test));  //outputs test
        }
    
        static string TestMethod(dynamic obj)
        {
            return obj.Text;
        }
    }
