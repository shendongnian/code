    public static void LeftClick(Point position)
        {
            Point cursorPosition;
            GetCursorPos(out cursorPosition);
            MoveMouseTo(position.X, position.Y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN | MouseEventFlags.LEFTUP | MouseEventFlags.ABSOLUTE), position.X, position.Y, 0, IntPtr.Zero);
            SetCursorPos(cursorPosition.X, cursorPosition.Y);
        }
