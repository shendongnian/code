    class Demo {
        readonly Func<ReadOnlyCollection<string>> _getItems;
        public Demo() {
            var items = new Lazy<List<string>>( ExpensiveOperation);
            _getItems = () => items.Value.AsReadOnly();
        }
        ReadOnlyCollection<string> Items { get { return _getItems(); }}
     }
