    namespace Database {
        public class ItemInsertError : Exception {
            public ItemInsertError() : base() {}
            public void ItemInsertError(string message) : base(message) {}
        }
    }
