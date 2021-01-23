    public static class Foo {
        private static int bar = 5;
        public static int Bar {
            get {
                return bar;
            }
            set {
                bar = value;
                //callback here
            }
        }
    }
