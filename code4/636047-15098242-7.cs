    public class Foo
    {
        public double Value { get; set; }
    }
    private static void Main(string[] args)
    {
        Foo[] array = new Foo[5];
        //populate array with values
        array.BinarySearch(.25, item => item.Value);
    }
