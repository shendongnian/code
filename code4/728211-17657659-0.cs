    public class Foo
    {
        private Stack<Action> stack = new Stack<Action>();
        public event Action MyEvent
        {
            add
            {
                stack.Push(value);
            }
            remove { throw new NotImplementedException(); }
        }
        internal void OnMyEvent()
        {
            foreach (var action in stack)
                action();
        }
    }
