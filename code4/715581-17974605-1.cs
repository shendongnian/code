    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        internal InputType type;
        internal InputUnion U;
        internal static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }
    [Flags]
    public enum KeyFlag
    {
        KeyDown = 0x0000,
        KeyUp = 0x0002,
        Scancode = 0x0008
    }
    public static void SendKey(shot keyCode, KeyFlag keyFlag)
    {
         INPUT[] InputData = new INPUT[1];
         InputData[0].type = 1;
         InputData[0].ki.wScan = keyCode; // 0x14 = T for example
         InputData[0].ki.dwFlags = (int)keyFlag;
         InputData[0].ki.time = 0;
         InputData[0].ki.dwExtraInfo = IntPtr.Zero;
         SendInput(1, InputData, Marshal.SizeOf(typeof(INPUT)));
    }
    public static void PressKey(short key)
    {
        SendKey(key, KeyFlag.KeyDown | KeyFlag.Scancode);
        SendKey(key, KeyFlag.KeyUp | KeyFlag.Scancode);
    }
