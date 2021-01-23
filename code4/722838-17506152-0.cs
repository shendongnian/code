    public class A
    {
        public void PrintType()
        {
            Console.WriteLine(this.GetType().ToString());
        }
    }
    public class B : A
    {
    }
    // ...
    new B().PrintType(); // This will give "B", not "A".
