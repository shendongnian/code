    public const int WM_POINTERDOWN = 0x0246;
    public const int WM_POINTERUP = 0x0247;
    public const int WM_POINTERUPDATE = 0x0245;
    public enum POINTER_INPUT_TYPE : int
    {
        PT_POINTER = 0x00000001,
        PT_TOUCH   = 0x00000002,
        PT_PEN     = 0x00000003,
        PT_MOUSE   = 0x00000004
    }
    public static uint GET_POINTERID_WPARAM(uint wParam) { return wParam & 0xFFFF; }
    [DllImport("User32.dll")]
    public static extern bool GetPointerType(uint pPointerID, out POINTER_INPUT_TYPE pPointerType);
    protected override void WndProc(ref Message m)
    {
        bool handled = false;
        uint pointerID;
        POINTER_INPUT_TYPE pointerType;
        switch(m.Message)
        {
            case WM_POINTERDOWN:
                 pointerID = User32.GET_POINTERID_WPARAM((uint)m.WParam);
                 if (User32.GetPointerType(pointerID, out pointerType))
                 {
                     switch (pointerType)
                     {
                         case POINTER_INPUT_TYPE.PT_PEN:
                             // Stylus Down
                             handled = true;
                             break;
                         case POINTER_INPUT_TYPE.PT_TOUCH:
                             // Touch down
                             handled = true;
                             break;
                     }
                 }
                 break;
        }
        if (handled)
            m.Result = (IntPtr)1;
        base.WndProc(ref m);
    }
