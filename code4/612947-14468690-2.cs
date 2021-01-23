    public class TrivialClass
    {
        public static readonly TrivialClass Empty = new TrivialClass(0);
        public int MyValue;
        public TrivialClass(int InitialValue)
        {
            MyValue = InitialValue;
        }
    }
