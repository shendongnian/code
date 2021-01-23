    public class MyClass
    {
        public static string DoStuff(string input)
        {
            Console.WriteLine("Did stuff: " + input);
            return "Did stuff";
        }
    }
    public class Host
    {
        public void Main()
        {
            MyClass.DoStuff("something");
        }
    }
