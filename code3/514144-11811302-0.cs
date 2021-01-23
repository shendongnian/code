    /// <summary>
    /// A class that manages a global low level keyboard hook
    /// </summary>
    class GlobalKeyboardHook
    {
        #region Constant, Structure and Delegate Definitions
        /// <summary>
        /// defines the callback type for the hook
        /// </summary>
        public delegate int KeyboardHookProc(int code, int wParam, ref KeyboardHookStruct lParam);
        public struct KeyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;
        #endregion
        /// <summary>
        /// The collections of keys to watch for
        /// </summary>
        public List<Keys> HookedKeys = new List<Keys>();
        /// <summary>
        /// Handle to the hook, need this to unhook and call the next hook
        /// </summary>
        private IntPtr _hhook = IntPtr.Zero;
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalKeyboardHook"/> class and installs the keyboard hook.
        /// </summary>
        public GlobalKeyboardHook()
        {
            this.Hook();
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="GlobalKeyboardHook"/> is reclaimed by garbage collection and uninstalls the keyboard hook.
        /// </summary>
        ~GlobalKeyboardHook()
        {
            this.Unhook();
        }
        /// <summary>
        /// Installs the global hook
        /// </summary>
        public void Hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            this._hhook = SetWindowsHookEx(WH_KEYBOARD_LL, this.HookProc, hInstance, 0);
        }
        /// <summary>
        /// Uninstalls the global hook
        /// </summary>
        public void Unhook()
        {
            UnhookWindowsHookEx(this._hhook);
        }
        /// <summary>
        /// The callback for the keyboard hook
        /// </summary>
        /// <param name="code">The hook code, if it isn't >= 0, the function shouldn't do anyting</param>
        /// <param name="wParam">The event type</param>
        /// <param name="lParam">The keyhook event information</param>
        /// <returns></returns>
        private int HookProc(int code, int wParam, ref KeyboardHookStruct lParam)
        {
            if (code >= 0)
            {
                var key = (Keys) lParam.vkCode;
                if (this.HookedKeys.Contains(key))
                {
                    var handler = this.KeyPressed;
                    if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (handler != null))
                    {
                        ModifierKeys mods = 0;
                        if (Keyboard.IsKeyDown(Keys.Control) || Keyboard.IsKeyDown(Keys.ControlKey) ||
                            Keyboard.IsKeyDown(Keys.LControlKey) || Keyboard.IsKeyDown(Keys.RControlKey))
                        {
                            mods |= ModifierKeys.Control;
                        }
                        if (Keyboard.IsKeyDown(Keys.Shift) || Keyboard.IsKeyDown(Keys.ShiftKey) ||
                            Keyboard.IsKeyDown(Keys.LShiftKey) || Keyboard.IsKeyDown(Keys.RShiftKey))
                        {
                            mods |= ModifierKeys.Shift;
                        }
                        if (Keyboard.IsKeyDown(Keys.LWin) || Keyboard.IsKeyDown(Keys.RWin))
                        {
                            mods |= ModifierKeys.Win;
                        }
                        if (Keyboard.IsKeyDown(Keys.Alt))
                        {
                            mods |= ModifierKeys.Alt;
                        }
                        handler(this, new KeyPressedEventArgs(mods, key));
                    }
                }
            }
            return CallNextHookEx(this._hhook, code, wParam, ref lParam);
        }
        public event EventHandler<KeyPressedEventArgs> KeyPressed;
        #region DLL imports
        /// <summary>
        /// Sets the windows hook, do the desired event, one of hInstance or threadId must be non-null
        /// </summary>
        /// <param name="idHook">The id of the event you want to hook</param>
        /// <param name="callback">The callback.</param>
        /// <param name="hInstance">The handle you want to attach the event to, can be null</param>
        /// <param name="threadId">The thread you want to attach the event to, can be null</param>
        /// <returns>a handle to the desired hook</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc callback, IntPtr hInstance, uint threadId);
        /// <summary>
        /// Unhooks the windows hook.
        /// </summary>
        /// <param name="hInstance">The hook handle that was returned from SetWindowsHookEx</param>
        /// <returns>True if successful, false otherwise</returns>
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        /// <summary>
        /// Calls the next hook.
        /// </summary>
        /// <param name="idHook">The hook id</param>
        /// <param name="nCode">The hook code</param>
        /// <param name="wParam">The wparam.</param>
        /// <param name="lParam">The lparam.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref KeyboardHookStruct lParam);
        /// <summary>
        /// Loads the library.
        /// </summary>
        /// <param name="lpFileName">Name of the library</param>
        /// <returns>A handle to the library</returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);
        #endregion
    }
    static class Keyboard
    {
        [Flags]
        private enum KeyStates
        {
            None = 0,
            Down = 1,
            Toggled = 2
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);
        private static KeyStates GetKeyState(Keys key)
        {
            KeyStates state = KeyStates.None;
            short retVal = GetKeyState((int)key);
            //If the high-order bit is 1, the key is down
            //otherwise, it is up.
            if ((retVal & 0x8000) == 0x8000)
                state |= KeyStates.Down;
            //If the low-order bit is 1, the key is toggled.
            if ((retVal & 1) == 1)
                state |= KeyStates.Toggled;
            return state;
        }
        public static bool IsKeyDown(Keys key)
        {
            return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
        }
        public static bool IsKeyToggled(Keys key)
        {
            return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
        }
    }
    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    class KeyPressedEventArgs : EventArgs
    {
        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            this.Modifier = modifier;
            this.Key = key;
            this.Ctrl = (modifier & ModifierKeys.Control) != 0;
            this.Shift = (modifier & ModifierKeys.Shift) != 0;
            this.Win = (modifier & ModifierKeys.Win) != 0;
            this.Alt = (modifier & ModifierKeys.Alt) != 0;
        }
        public ModifierKeys Modifier { get; private set; }
        public Keys Key { get; private set; }
        public readonly bool Ctrl;
        public readonly bool Shift;
        public readonly bool Win;
        public readonly bool Alt;
    }
    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
