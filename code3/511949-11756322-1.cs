    public class MyWrapper {
        public double? Value {get;set;}
        public static implicit operator double?(MyWrapper value) {
            return value == null ? null : value.Value;
        }
    }
