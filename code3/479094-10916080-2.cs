    public static class test {
    static void Main(string[] args)
    {
        Foo();
        Foo("test");
    }
    public void Foo()
    {
        Console.WriteLine("No message supplied");
    }
    public void Foo(string message)
    {
        Console.WriteLine(message);
    }
