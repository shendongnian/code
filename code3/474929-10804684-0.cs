    using System;
    using System.Threading.Tasks;
    
    class Test
    {
        static void Main()
        {
            Task t = Foo();
            t.Wait();
        }
        
        static async Task Foo()
        {
            try
            {
                await Task.Run(() => { throw new Exception(); });
            }
            catch (Exception e)
            {
                Console.WriteLine("Bang! " + e);
            }
        }
