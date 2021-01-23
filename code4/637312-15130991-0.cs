    public static class ButtonExtensions {
        // Button indirectly extends Control
        // Control has a protected method: protected void OnClick(EventArgs e);
        // you can't call it directly, you need to do it via reflection
        private static readonly MethodInfo controlsOnClickMethod = typeof(Control).GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic);
        // Although the second parameter of the Button.Click event
        // is syntactically: EventArgs
        // at runtime, it is usually a MouseEventArgs
        // so that's what we're going to send it
        public static void PerformClickEx(this Button @this, MouseEventArgs args) {
            ButtonExtensions.controlsOnClickMethod.Invoke(@this, new object[] { args });
        }
    }
