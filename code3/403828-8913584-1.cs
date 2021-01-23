    protected override void OnMouseDown(MouseEventArgs e)
    {
        int msg = -1; //if (msg == -1) at the end of this, then the mousedown is not a drag.
        if (e.Y < 8)
        {
            msg = 12; //Top
            if (e.X < 25) msg = 13; //Top Left
            if (e.X > Width - 25) msg = 14; //Top Right
        }
        else if (e.X < 8)
        {
            msg = 10; //Left
            if (e.Y < 17) msg = 13;
            if (e.Y > Height - 17) msg = 16;
        }
        else if (e.Y > Height - 9)
        {
            msg = 15; //Bottom
            if (e.X < 25) msg = 16;
            if (e.X > Width - 25) msg = 17;
        }
        else if (e.X > Width - 9)
        {
            msg = 11; //Right
            if (e.Y < 17) msg = 14;
            if (e.Y > Height - 17) msg = 17;
        }
        
        if (msg != -1)
        {
            UnsafeNativeMethods.ReleaseCapture(); //Release current mouse capture
            UnsafeNativeMethods.SendMessage(Handle, 0xA1, new IntPtr(msg), IntPtr.Zero);
            //Tell the OS that you want to drag the window.
        }
    }
