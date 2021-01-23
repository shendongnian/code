    class Demo {
        readonly Lazy<List<string>> _items;
        public Demo() {
            var _items = new Lazy<List<string>>( ExpensiveOperation);
        }
        List<string> Items { get { return _items.Value; }}
     }
     
