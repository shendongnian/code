    public class Foo
    {
        public int  _foo;
        public int? _bar;
        
        public void Output()
        {
            Console.WriteLine(this._foo); // Outputs: 0
            Console.WriteLine(this._bar.HasValue ? "not null" : "null"); // Outputs: null
        }
    }
