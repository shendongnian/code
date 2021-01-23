        public static void Suspend(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                IntPtr.Zero);
            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
        }
        public static void Resume(Control control)
        {
            // Create a C "true" boolean as an IntPtr
            IntPtr wparam = new IntPtr(1);
            Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                IntPtr.Zero);
            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgResumeUpdate);
            control.Invalidate();
        }
        public static Point GetScrollPoint(Control control) {
            Point point = new Point();
            SendMessage(control.Handle, EM_GETSCROLLPOS, 0, ref point);
            return point;
        }
        public static void SetScrollPoint(Control control, Point point)
        {
            SendMessage(control.Handle, EM_SETSCROLLPOS, 0, ref point);
        }
