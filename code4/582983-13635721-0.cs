    internal class Program
    {
        static Task Boo()
        {
            return Task.Run(() =>
                            {
                                throw new Exception("111");
                            });
        }
    
        private static async void Foo()
        {
            await Boo();
        }
    
        static void Main(string[] args)
        {
            // Application will blow with DomainUnhandled excpeption!
            try
            {
                Foo();
            }
            catch (Exception e)
            {
                // Will not catch it here!
                Console.WriteLine(e);
            }
    
            Console.ReadLine();
        }
    }
