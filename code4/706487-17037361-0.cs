    public interface IBoth<TFirst, TSecond> {
        TFirst AsFirst();
        TSecond AsSecond();
    }
    public class Wrapper<T, TFirst, TSecond> : IBoth<TFirst, TSecond>
       where T : TFirst, TSecond
    {
        private readonly T _value;
        public Wrapper(T value) {
            _value = value;
        }
        public TFirst AsFirst() {
            return _value;
        }
        public TSecond AsSecond() {
            return _value;
        }
    }
