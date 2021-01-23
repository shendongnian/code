    public static class ControlExtensions
    {
        public static void Synchronize(this Control control, Action action)
        {
            if (control == null || !control.InvokeRequired)
            {
                action();
            }
            else
            {
                control.Invoke(action, null);
            }
        }
    }
