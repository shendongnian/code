     class Program
    {
        static void Main(string[] args)
        {
            var writer = new Writer();
            var task = Task.Factory.StartNew(() =>
                {
                    writer.Write("1");
                });
            task.ContinueWith((data) =>
            {
                writer.Write("0");
            });
            Console.ReadKey();
        }
    }
    public class Writer
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
    }
