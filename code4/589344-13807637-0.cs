    public static partial class Extension {
        public static SerializableDictionary<T, Q> ToSerializableDictionary(
            this IDictionary<T, Q> d) {
            return new SerializableDictionary(d);
        }
    }
