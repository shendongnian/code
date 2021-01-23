    class SerializableEntity<T> {
        public SerializableEntity(T obj) { }
    }
    static class P {
        public static void serialize<T>(T serializeObject) {
            //this is fine...
            SerializableEntity<T> entity =
                new SerializableEntity<T>(serializeObject);
        }
        static void Main() { /*...*/ }
    }
