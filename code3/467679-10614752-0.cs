    public void Test(Func<int> func)
    {        
        var watch = new Stopwatch();
        watch.Start();
        for (var i = 0; i <= 1000000; i++)
        {
            var test = func();
        }
        Console.WriteLine(watch.ElapsedMilliseconds);
    }
    
    public class FooClass { public int Execute() { return 1;}}
