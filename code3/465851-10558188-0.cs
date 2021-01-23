    internal static class ControlExtensions
    {
        internal static void Invoke(this Control control, Action action)
        {
            control.Invoke(action);
        }
     }
