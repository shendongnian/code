    [DllImport("user32.dll", SetLastError = true)]
    static extern UInt32 SendInput(UInt32 numberOfInputs, INPUT[] inputs, Int32 sizeOfInputStructure);
    public static void SimulateTextEntry(string text)
    {
        if (text.Length > UInt32.MaxValue / 2) throw new ArgumentException(string.Format("The text parameter is too long. It must be less than {0} characters.", UInt32.MaxValue / 2), "text");
        var chars = UTF8Encoding.ASCII.GetBytes(text);
        var len = chars.Length;
        INPUT[] inputList = new INPUT[len * 2];
        for (int x = 0; x < len; x++)
        {
            UInt16 scanCode = chars[x];
            var down = new INPUT();
            down.Type = (UInt32)InputType.KEYBOARD;
            down.Data.Keyboard = new KEYBDINPUT();
            down.Data.Keyboard.Vk = 0;
            down.Data.Keyboard.Scan = scanCode;
            down.Data.Keyboard.Flags = (UInt32)KeyboardFlag.UNICODE;
            down.Data.Keyboard.Time = 0;
            down.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            var up = new INPUT();
            up.Type = (UInt32)InputType.KEYBOARD;
            up.Data.Keyboard = new KEYBDINPUT();
            up.Data.Keyboard.Vk = 0;
            up.Data.Keyboard.Scan = scanCode;
            up.Data.Keyboard.Flags = (UInt32)(KeyboardFlag.KEYUP | KeyboardFlag.UNICODE);
            up.Data.Keyboard.Time = 0;
            up.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            // Handle extended keys:
            // If the scan code is preceded by a prefix byte that has the value 0xE0 (224),
            // we need to include the KEYEVENTF_EXTENDEDKEY flag in the Flags property. 
            if ((scanCode & 0xFF00) == 0xE000)
            {
                down.Data.Keyboard.Flags |= (UInt32)KeyboardFlag.EXTENDEDKEY;
                up.Data.Keyboard.Flags |= (UInt32)KeyboardFlag.EXTENDEDKEY;
            }
            inputList[2*x] = down;
            inputList[2*x + 1] = up;
        }
        var numberOfSuccessfulSimulatedInputs = SendInput((UInt32)len*2, inputList, Marshal.SizeOf(typeof(INPUT)));
    }
