    // TODO: Work out which collection interfaces you want to implement
    public class BaseList
    {
        // Or use List<IBase>, if that's how you'll be using it more often.
        private List<Base> list = new List<Base>();
        public void Add<T>(T item) where T : Base, IBase
        {
            list.Add(item);
        }
    }
