    INPUT[] inputs = new INPUT[]
    {
        new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new InputUnion
            {
                ki = new KEYBDINPUT
                {
                    wVk = key,
                    wScan = 0,
                    dwFlags = 0,
                    dwExtraInfo = GetMessageExtraInfo(),
                }
            }
        }
    };
    SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
