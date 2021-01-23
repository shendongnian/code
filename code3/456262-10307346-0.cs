    public static class ControlExtensions {
        public static T GuiThread<T>(this Control ctrl, Func<T> action) {
            if (ctrl.InvokeRequired) {
                return (T)ctrl.Invoke(action);
            }
            else {
                return action();
            }
        }
    }
