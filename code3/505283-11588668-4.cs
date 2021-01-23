    public struct MyBool {
        public MyBool(bool value) : this() {
            this.Value = value;
        }
        public bool Value { get; private set; }
    }
    public static MyBoolExtensions {
        public static char convert_to_YorN(this MyBool value) {
            return value.Value ? 'Y' : 'N';
        }
    }
    public static BooleanExtensions {
        public static MyBool bool_ext(this bool value) {
            return new MyBool(value);
        }
    }
