    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread thread = new Thread((s) =>
                    {
                        throw new Exception("Blah");
                    });
                thread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught: {0}", ex);
            }
            Console.ReadKey();
        }
    }
