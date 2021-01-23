    public static class ControlExtensions
    {
        public static void SimulateClick(this Control c)
        {
            c.RaiseEvent("Click", EventArgs.Empty);
        }
        public static void RaiseEvent(this Control c, string eventName, EventArgs e)
        {
            // TO simulate the delegate invocation we obtain it's invocation list
            // and walk it, invoking each item in the list
            Type t = c.GetType();
            FieldInfo fi = t.GetField(eventName, BindingFlags.NonPublic | BindingFlags.Instance);
            MulticastDelegate d = fi.GetValue(c) as MulticastDelegate;
            Delegate[] list = d.GetInvocationList();
            // It is important to cast each member to an appropriate delegate type
            // For example for the KeyDown event we would replace EventHandler
            // with KeyEvenHandler and new EventArgs() with new KeyHandlerEventArgs()
            foreach (EventHandler del in list)
            {
                del.Invoke(c, e);
            }
        }
    }
