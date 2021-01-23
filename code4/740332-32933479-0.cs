    public class ConsoleProgress<T> : IProgress<T>
    {
        private Action<T> _action;
        public ConsoleProgress(Action<T> action) {
            if(action == null) {
                throw new ArgumentNullException(nameof(action));
            }
            _action = action;
        }
        public void Report(T value) {
            _action(value);
        }
    }
