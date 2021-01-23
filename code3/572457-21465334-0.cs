    class Foo : IDisposable
    {
        public event EventHandler MyEvent;
        /// <summary>
        /// When disposing unsubscibe from all events
        /// </summary>
        public void Dispose()
        {
            if (MyEvent != null)
            {
                foreach (Delegate del in MyEvent.GetInvocationList())
                    MyEvent -= (del as EventHandler);
            }
            // do the same for any other events in the class
            //  ....
        }
    }
