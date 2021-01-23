    public class Demo
    {
        private readonly Func<List<string>> _getItems;
        public Demo()
        {
            List<string> items = null;
            _getItems = () =>
            {
                if (items == null)
                    items = ExpensiveOperation();
                return items;
            };
        }
        public List<string> Items { get { return _getItems(); } }
    }
