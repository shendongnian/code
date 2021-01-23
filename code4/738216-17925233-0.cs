    partial class Program
    {
        static partial void foo();
        static partial void fooDebug();
        static partial void fooBar();
        static partial void foo()
        {
            Console.WriteLine("foo");
        }
    #if DEBUG
        static partial void fooDebug()
        {
            Console.WriteLine("fooDebug");
        }
    #endif
    #if BAR
        static partial void fooBar()
        {
            Console.WriteLine("fooBar");
        }
    #endif
        //In this example, I want to find a way where only foo() and fooDebug() are called and fooBar() is ignored, when reflected.
        static void Main(string[] args)
        {
            //Call methods directly.
            //Methods are called/ignored as expected.
            foo();//not ignored
            fooDebug();//not ignored
            fooBar();//ignored
