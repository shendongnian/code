    public class Foo {
        private int _value;
        public int Bar {
            set {
                _value = value * Baz; // don't want to do this if initializing
            }
        }
        public int Baz { get; set; }
    }
