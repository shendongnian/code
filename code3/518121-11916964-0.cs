    public static class UI
    {
        private static Control internalControl;
        public static void Initialize(Control control)
        {
            internalControl = control;
        }
        public static void Invoke(Action action)
        {
            if (internalControl.InvokeRequired)
            {
                internalControl.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
