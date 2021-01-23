    public class DisposeTest : IDisposable
    {
        public void Run()
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromDays(1));
            }
            
            Dispose();
            
        }
        public void Dispose()
        {
            Console.WriteLine("disposing");
        }
    }
    public class TestDriver
    {
        static void Main(string[] args)
        {
            var diposeTest = new DisposeTest();
            var thread = new Thread(diposeTest.Run)
                                {
                                    IsBackground = true
                                };
            thread.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
