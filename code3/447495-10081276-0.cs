    struct AmNull {
        public static bool operator ==(AmNull a, object b) {
            return b == null;
        }
        public static bool operator !=(AmNull a, object b) {
            return b != null;
        }
    }
    ...
    Console.WriteLine(new AmNull() == null); // True
