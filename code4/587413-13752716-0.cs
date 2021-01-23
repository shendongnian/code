    public class Foo
    {
        public void Bar(string value)
        {
            Console.WriteLine(value);
        }
    
        public void Bar()
        {
            Bar("I have no value :(");
        }
    }
