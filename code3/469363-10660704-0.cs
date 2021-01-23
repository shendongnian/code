    public static class SimInput
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);
        [Flags]
        public enum MouseEventFlags : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            Absolute = 0x8000
        }
        public static void MouseEvent(MouseEventFlags e, uint x, uint y)
        {
            mouse_event((uint)e, x, y, 0, UIntPtr.Zero);
        }
        public static void LeftClick(Point p)
        {
            LeftClick((double)p.X, (double)p.Y);
        }
        public static void LeftClick(double x, double y)
        {
            var scr = Screen.PrimaryScreen.Bounds;
            MouseEvent(MouseEventFlags.LeftDown | MouseEventFlags.LeftUp | MouseEventFlags.Move | MouseEventFlags.Absolute,
                (uint)Math.Round(x / scr.Width * 65535),
                (uint)Math.Round(y / scr.Height * 65535));
        }
        public static void LeftClick(int x, int y)
        {
            LeftClick((double)x, (double)y);
        }
    }
