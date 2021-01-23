    public class MyTest
    {
        public void RunTest()
        {
            Task<Int32> t = Task.Run<Int32>(() => MyIntReturningMethod());
            t.Wait();
            Console.WriteLine(t.Result);
        }
    
        public int MyIntReturningMethod()
        {
            return (5);
        }
    }
