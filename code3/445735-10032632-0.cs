    public class MyBar:Bar
    {
        // internal constructor
        public MyBar(object throwaway)
        {
           //call base constructor if necessary
        };
        public int Id { get; }
        public string Name { get; }
        public Foo Foo { get; }
    }
