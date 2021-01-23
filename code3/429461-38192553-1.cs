        private static bool _exiting;
        private static readonly object SynchObj = new object();
        public static void InvokeIfRequired<TControl>(this TControl control, MethodInvokerEx<TControl> action) where TControl : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action, control);
            }
            else
            {
                action(control);
            }
        }
