    /// <summary>
    /// Synthesizes keystrokes corresponding to the specified Unicode string,
    /// sending them to the currently active window.
    /// </summary>
    /// <param name="s">The string to send.</param>
    public static void SendString(string s)
    {
        // Construct list of inputs in order to send them through a single SendInput call at the end.
        List<INPUT> inputs = new List<INPUT>();
        // Loop through each Unicode character in the string.
        foreach (char c in s)
        {
            // First send a key down, then a key up.
            foreach (bool keyUp in new bool[] { false, true })
            {
                // INPUT is a multi-purpose structure which can be used 
                // for synthesizing keystrokes, mouse motions, and button clicks.
                INPUT input = new INPUT
                {
                    // Need a keyboard event.
                    type = INPUT_KEYBOARD,
                    u = new InputUnion
                    {
                        // KEYBDINPUT will contain all the information for a single keyboard event
                        // (more precisely, for a single key-down or key-up).
                        ki = new KEYBDINPUT
                        {
                            // Virtual-key code must be 0 since we are sending Unicode characters.
                            wVk = 0,
                            // The Unicode character to be sent.
                            wScan = c,
                            // Indicate that we are sending a Unicode character.
                            // Also indicate key-up on the second iteration.
                            dwFlags = KEYEVENTF_UNICODE | (keyUp ? KEYEVENTF_KEYUP : 0),
                            dwExtraInfo = GetMessageExtraInfo(),
                        }
                    }
                };
                // Add to the list (to be sent later).
                inputs.Add(input);
            }
        }
        // Send all inputs together using a Windows API call.
        SendInput((uint)inputs.Count, inputs.ToArray(), Marshal.SizeOf(typeof(INPUT)));
    }
    const int INPUT_MOUSE = 0;
    const int INPUT_KEYBOARD = 1;
    const int INPUT_HARDWARE = 2;
    const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
    const uint KEYEVENTF_KEYUP = 0x0002;
    const uint KEYEVENTF_UNICODE = 0x0004;
    const uint KEYEVENTF_SCANCODE = 0x0008;
    const uint XBUTTON1 = 0x0001;
    const uint XBUTTON2 = 0x0002;
    const uint MOUSEEVENTF_MOVE = 0x0001;
    const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    const uint MOUSEEVENTF_LEFTUP = 0x0004;
    const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
    const uint MOUSEEVENTF_RIGHTUP = 0x0010;
    const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
    const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
    const uint MOUSEEVENTF_XDOWN = 0x0080;
    const uint MOUSEEVENTF_XUP = 0x0100;
    const uint MOUSEEVENTF_WHEEL = 0x0800;
    const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
    const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
    
    struct INPUT
    {
        public int type;
        public InputUnion u;
    }
    [StructLayout(LayoutKind.Explicit)]
    struct InputUnion
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;
        [FieldOffset(0)]
        public KEYBDINPUT ki;
        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct KEYBDINPUT
    {
        /*Virtual Key code.  Must be from 1-254.  If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0.*/
        public ushort wVk;
        /*A hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application.*/
        public ushort wScan;
        /*Specifies various aspects of a keystroke.  See the KEYEVENTF_ constants for more information.*/
        public uint dwFlags;
        /*The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.*/
        public uint time;
        /*An additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information.*/
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }
    [DllImport("user32.dll")]
    static extern IntPtr GetMessageExtraInfo();
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
    
