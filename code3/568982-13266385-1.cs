    public class MyExtendedList : IEnumerable
    {
        private List<string> original;
        public MyExtendedList(List<String> original)
        {
            this.original = original;
        }
        public IEnumerator GetEnumerator()
        {
            return new ExtendedEnum(original);
        }
    }
    public class ExtendedEnum : IEnumerator
    {
        private List<string> original;
        private int position = -1;
        public ExtendedEnum(List<String> original)
        {
            this.original = original;
        }
        public object Current
        {
            get
            {
                return Current;
            }
        }
        public bool MoveNext()
        {
            position++;
            return (position < original.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        public String CurrentString
        {
            get
            {
                try
                {
                    return original[position] + "_extension";
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
