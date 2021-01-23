    static class Raiser
    {
        public static void Raise<T>(this EventHandler<T> evnt, object sender, T args)
            where T : EventArgs
        {
            if (evnt != null)
            {
                evnt(sender, args);
            }
        }
    }
    class SomeClass
    {
        public event EventHandler<EventArgs> MyEvent;
        private void DoSomething()
        {
            MyEvent.Raise(this, EventArgs.Empty);
        }
    }
