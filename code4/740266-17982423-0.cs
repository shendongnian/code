    class Button<T>
    {
        public T Item { get; private set; }
        public Button(string name, T item, ...)
        {
            // Constructor code
        }
    }
    // Helper class for creation
    static class Button
    {
        public static Button<T> Create<T>(string name, T item, ...)
        {
            return new Button<T>(name, item, ...);
        }
    }
