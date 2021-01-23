    public interface I
    {
        int Foo { get; set; }
    }
    public class C : I
    {
        private int _foo;
        public int Foo
        {
            get {
                // getter
                return _foo;
            }
            set {
                // setter
                _foo = value;
            }
        }
    }
