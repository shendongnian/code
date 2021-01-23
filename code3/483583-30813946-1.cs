    public static class CommonExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SafeInvokeWithCancel<T>(this EventHandler<T> handler, object sender, T args) where T : CancelableEventArgs
        {
            if (handler != null)
            {
                foreach (var d in handler.GetInvocationList().Reverse())
                {
                    d.DynamicInvoke(sender, args);
                    if (args.Cancelled)
                    {
                        break;
                    }
                }
            }
        }
