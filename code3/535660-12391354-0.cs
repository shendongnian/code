    public class Program
    {
        static void Main()
        {
            Task.Factory.StartNew(() =>
            {
                using (var stream = File.OpenWrite("test.dat"))
                {
                    Thread.Sleep(100);
                }
            });
            Thread.Sleep(10);
            // prints True
            Console.WriteLine(File.Exists("test.dat"));
        }
    }
