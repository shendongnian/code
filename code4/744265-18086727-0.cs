    public static void SetControlPropertyThreadSafe<T>(T control, Action<T> action) where T : Control
        {
                if (control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action();
                }
        }
