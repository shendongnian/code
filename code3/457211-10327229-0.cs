    public abstract class Executable<T>
    {
        protected void Execute(Action<T> action, T value)
        {
            PreInvoke();
            action();
            PostInvoke();
        }
        private void PreInvoke() { /* something */ }
        private void PostInvoke() { /* something */ }
    }
    public MyFooExecutable : Executable<string>
    {
    }
