    class PropertyModel {
        private readonly string _name = "";
        private readonly object _value = null;
        
        public PropertyModel(string name, object value) {
           _name = name ?? "";
           _value = _value;
        }
        public string Name {
            get { return _name; }
        }
        public object Value {
            get { return _value; }
        }
    }
