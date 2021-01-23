    interface IWindowManager
    {
        void Show(Type type);
        void Show<T>();
        void ShowDialog(Type type);
        void ShowDialog<T>();
    }
    class WindowManager : IWindowManager
    {
        // Implementation of the four methods from the interface plus:
    
        private Dictionary<Type, Func<Window>> collection 
            = new Dictionary<Type, Func<Window>>();
    
        public void Bind(Func<Window> ctor, Type type) { ... }
    }
