    public interface ISetter {
        void SetValue<T>(T value);
    }
    public static class Store {
        public static Value A = new Value(new ASetter());
        public static Value B = new Value(new BSetter());
        public static Value C = new Value(new CSetter());
        class ASetter : ISetter {
            public void SetValue<T>(T value) { Store<T>.A = value; }
        }
        class BSetter : ISetter {
            public void SetValue<T>(T value) { Store<T>.B = value; }
        }
        class CSetter : ISetter {
            public void SetValue<T>(T value) { Store<T>.C = value; }
        }
    }
    public class Value {
        ISetter _setter;
        public Value(ISetter setter) {
            _setter = setter;
        }
        public void SetValue<T> (T value) {
            _setter.SetValue<T>(value);
        }
    }
