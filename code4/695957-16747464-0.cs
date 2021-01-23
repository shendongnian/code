    class Container {
        public int X { get; set; }
        public Container() {
            X = 10;
        }
    }
    // .. elsewhere...
    object getVariableValueByStringName(string str) {
        return typeof(Container).GetProperty(str).GetValue(new Container() /* <-- dummy or not.. up to you -->);
    }
