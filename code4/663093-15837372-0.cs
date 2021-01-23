    public static class FormsExt
    {
        public static void InvokeOnMainThread(this System.Windows.Forms.Control control, Action act)
        {
            control.Invoke(new MethodInvoker(act), null);
        }
    }
