KeyboardListener.cs
/// <summary>
    /// Listens keyboard globally.
    /// 
    /// <remarks>Uses WH_KEYBOARD_LL.</remarks>
    /// </summary>
    public class KeyboardListener : IDisposable
    {
        /// <summary>
        /// Creates global keyboard listener.
        /// </summary>
        public KeyboardListener(Dispatcher dispatcher)
        {
            // Dispatcher thread handling the KeyDown/KeyUp events.
            _dispatcher = dispatcher;
            // We have to store the LowLevelKeyboardProc, so that it is not garbage collected runtime
            _hookedLowLevelKeyboardProc = LowLevelKeyboardProc;
            // Set the hook
            _hookId = InterceptKeys.SetHook(_hookedLowLevelKeyboardProc);
            // Assign the asynchronous callback event
            _hookedKeyboardCallbackAsync = new KeyboardCallbackAsync(KeyboardListener_KeyboardCallbackAsync);
        }
        private readonly Dispatcher _dispatcher;
        /// <summary>
        /// Destroys global keyboard listener.
        /// </summary>
        ~KeyboardListener()
        {
            Dispose();
        }
        /// <summary>
        /// Fired when any of the keys is pressed down.
        /// </summary>
        public event EventHandler<RawKeyEventArgs> KeyDown;
        /// <summary>
        /// Fired when any of the keys is released.
        /// </summary>
        public event EventHandler<RawKeyEventArgs> KeyUp;
        #region Inner workings
        /// <summary>
        /// Hook ID
        /// </summary>
        private readonly IntPtr _hookId = IntPtr.Zero;
        /// <summary>
        /// Asynchronous callback hook.
        /// </summary>
        /// <param name="character">Character</param>
        /// <param name="keyEvent">Keyboard event</param>
        /// <param name="vkCode">VKCode</param>
        private delegate void KeyboardCallbackAsync(InterceptKeys.KeyEvent keyEvent, int vkCode, string character);
        /// <summary>
        /// Actual callback hook.
        /// 
        /// <remarks>Calls asynchronously the asyncCallback.</remarks>
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private IntPtr LowLevelKeyboardProc(int nCode, UIntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
                if (wParam.ToUInt32() == (int)InterceptKeys.KeyEvent.WM_KEYDOWN ||
                    wParam.ToUInt32() == (int)InterceptKeys.KeyEvent.WM_KEYUP ||
                    wParam.ToUInt32() == (int)InterceptKeys.KeyEvent.WM_SYSKEYDOWN ||
                    wParam.ToUInt32() == (int)InterceptKeys.KeyEvent.WM_SYSKEYUP)
                {
                    // Captures the character(s) pressed only on WM_KEYDOWN
                    string chars = InterceptKeys.VKCodeToString((uint)Marshal.ReadInt32(lParam),
                                                                (wParam.ToUInt32() == (int)InterceptKeys.KeyEvent.WM_KEYDOWN ||
                                                                 wParam.ToUInt32() == (int)InterceptKeys.KeyEvent.WM_SYSKEYDOWN));
                    _hookedKeyboardCallbackAsync.BeginInvoke((InterceptKeys.KeyEvent)wParam.ToUInt32(), Marshal.ReadInt32(lParam), chars, null, null);
                }
            return InterceptKeys.CallNextHookEx(_hookId, nCode, wParam, lParam);
        }
        /// <summary>
        /// Event to be invoked asynchronously (BeginInvoke) each time key is pressed.
        /// </summary>
        private readonly KeyboardCallbackAsync _hookedKeyboardCallbackAsync;
        /// <summary>
        /// Contains the hooked callback in runtime.
        /// </summary>
        private readonly InterceptKeys.LowLevelKeyboardProc _hookedLowLevelKeyboardProc;
        /// <summary>
        /// HookCallbackAsync procedure that calls accordingly the KeyDown or KeyUp events.
        /// </summary>
        /// <param name="keyEvent">Keyboard event</param>
        /// <param name="vkCode">VKCode</param>
        /// <param name="character">Character as string.</param>
        void KeyboardListener_KeyboardCallbackAsync(InterceptKeys.KeyEvent keyEvent, int vkCode, string character)
        {
            switch (keyEvent)
            {
                // KeyDown events
                case InterceptKeys.KeyEvent.WM_KEYDOWN:
                    if (KeyDown != null)
                        _dispatcher.BeginInvoke(new EventHandler<RawKeyEventArgs>(KeyDown), this, new RawKeyEventArgs(vkCode, false, character));
                    break;
                case InterceptKeys.KeyEvent.WM_SYSKEYDOWN:
                    if (KeyDown != null)
                        _dispatcher.BeginInvoke(new EventHandler<RawKeyEventArgs>(KeyDown), this, new RawKeyEventArgs(vkCode, true, character));
                    break;
                // KeyUp events
                case InterceptKeys.KeyEvent.WM_KEYUP:
                    if (KeyUp != null)
                        _dispatcher.BeginInvoke(new EventHandler<RawKeyEventArgs>(KeyUp), this, new RawKeyEventArgs(vkCode, false, character));
                    break;
                case InterceptKeys.KeyEvent.WM_SYSKEYUP:
                    if (KeyUp != null)
                        _dispatcher.BeginInvoke(new EventHandler<RawKeyEventArgs>(KeyUp), this, new RawKeyEventArgs(vkCode, true, character));
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region IDisposable Members
        /// <summary>
        /// Disposes the hook.
        /// <remarks>This call is required as it calls the UnhookWindowsHookEx.</remarks>
        /// </summary>
        public void Dispose()
        {
            InterceptKeys.UnhookWindowsHookEx(_hookId);
        }
        #endregion
    }
InterceptKeys.cs
    /// <summary>
    /// Winapi Key interception helper class.
    /// </summary>
    internal static class InterceptKeys
    {
        public delegate IntPtr LowLevelKeyboardProc(int nCode, UIntPtr wParam, IntPtr lParam);
        private const int WH_KEYBOARD_LL = 13;
        /// <summary>
        /// Key event
        /// </summary>
        public enum KeyEvent : int
        {
            /// <summary>
            /// Key down
            /// </summary>
            WM_KEYDOWN = 256,
            /// <summary>
            /// Key up
            /// </summary>
            WM_KEYUP = 257,
            /// <summary>
            /// System key up
            /// </summary>
            WM_SYSKEYUP = 261,
            /// <summary>
            /// System key down
            /// </summary>
            WM_SYSKEYDOWN = 260
        }
        public static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, UIntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #region Convert VKCode to string
        // Note: Sometimes single VKCode represents multiple chars, thus string. 
        // E.g. typing "^1" (notice that when pressing 1 the both characters appear, 
        // because of this behavior, "^" is called dead key)
        [DllImport("user32.dll")]
        private static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);
        [DllImport("user32.dll")]
        private static extern bool GetKeyboardState(byte[] lpKeyState);
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetKeyboardLayout(uint dwLayout);
        [DllImport("User32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("User32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();
        private static uint _lastVKCode = 0;
        private static uint _lastScanCode = 0;
        private static byte[] _lastKeyState = new byte[255];
        private static bool _lastIsDead = false;
        /// <summary>
        /// Convert VKCode to Unicode.
        /// <remarks>isKeyDown is required for because of keyboard state inconsistencies!</remarks>
        /// </summary>
        /// <param name="vkCode">VKCode</param>
        /// <param name="isKeyDown">Is the key down event?</param>
        /// <returns>String representing single unicode character.</returns>
        public static string VKCodeToString(uint vkCode, bool isKeyDown)
        {
            // ToUnicodeEx needs StringBuilder, it populates that during execution.
            var sbString = new System.Text.StringBuilder(5);
            var bKeyState = new byte[255];
            bool bKeyStateStatus;
            bool isDead = false;
            // Gets the current windows window handle, threadID, processID
            IntPtr currentHWnd = GetForegroundWindow();
            uint currentProcessID;
            uint currentWindowThreadID = GetWindowThreadProcessId(currentHWnd, out currentProcessID);
            // This programs Thread ID
            uint thisProgramThreadId = GetCurrentThreadId();
            // Attach to active thread so we can get that keyboard state
            if (AttachThreadInput(thisProgramThreadId, currentWindowThreadID, true))
            {
                // Current state of the modifiers in keyboard
                bKeyStateStatus = GetKeyboardState(bKeyState);
                // Detach
                AttachThreadInput(thisProgramThreadId, currentWindowThreadID, false);
            }
            else
            {
                // Could not attach, perhaps it is this process?
                bKeyStateStatus = GetKeyboardState(bKeyState);
            }
            // On failure we return empty string.
            if (!bKeyStateStatus)
                return "";
            // Gets the layout of keyboard
            IntPtr hkl = GetKeyboardLayout(currentWindowThreadID);
            // Maps the virtual keycode
            uint lScanCode = MapVirtualKeyEx(vkCode, 0, hkl);
            // Keyboard state goes inconsistent if this is not in place. In other words, we need to call above commands in UP events also.
            if (!isKeyDown)
                return "";
            // Converts the VKCode to unicode
            int relevantKeyCountInBuffer = ToUnicodeEx(vkCode, lScanCode, bKeyState, sbString, sbString.Capacity, (uint)0, hkl);
            string ret = "";
            switch (relevantKeyCountInBuffer)
            {
                    // Dead keys (^,`...)
                case -1:
                    isDead = true;
                    // We must clear the buffer because ToUnicodeEx messed it up, see below.
                    ClearKeyboardBuffer(vkCode, lScanCode, hkl);
                    break;
                case 0:
                    break;
                    // Single character in buffer
                case 1:
                    ret = sbString[0].ToString();
                    break;
                    // Two or more (only two of them is relevant)
                case 2:
                default:
                    ret = sbString.ToString().Substring(0, 2);
                    break;
            }
            // We inject the last dead key back, since ToUnicodeEx removed it.
            // More about this peculiar behavior see e.g: 
            //   http://www.experts-exchange.com/Programming/System/Windows__Programming/Q_23453780.html
            //   http://blogs.msdn.com/michkap/archive/2005/01/19/355870.aspx
            //   http://blogs.msdn.com/michkap/archive/2007/10/27/5717859.aspx
            if (_lastVKCode != 0 && _lastIsDead)
            {
                var sbTemp = new System.Text.StringBuilder(5);
                ToUnicodeEx(_lastVKCode, _lastScanCode, _lastKeyState, sbTemp, sbTemp.Capacity, (uint)0, hkl);
                _lastVKCode = 0;
                return ret;
            }
            // Save these
            _lastScanCode = lScanCode;
            _lastVKCode = vkCode;
            _lastIsDead = isDead;
            _lastKeyState = (byte[])bKeyState.Clone();
            return ret;
        }
        private static void ClearKeyboardBuffer(uint vk, uint sc, IntPtr hkl)
        {
            var sb = new System.Text.StringBuilder(10);
            int rc;
            do
            {
                var lpKeyStateNull = new Byte[255];
                rc = ToUnicodeEx(vk, sc, lpKeyStateNull, sb, sb.Capacity, 0, hkl);
            } while (rc < 0);
        }
        #endregion
    }
RawKeyEventArgs.cs
 /// <summary>
    /// Raw KeyEvent arguments.
    /// </summary>
    public class RawKeyEventArgs : EventArgs
    {
        public bool IsSysKey { get; private set; }
        public Key Key { get; private set; }
        public int VKCode { get; private set; }
        /// <summary>
        /// Convert to string.
        /// </summary>
        /// <returns>Returns string representation of this key, if not possible empty string is returned.</returns>
        public override string ToString()
        {
            if (Character == null)
                return string.Empty;
            return Character;
        }
        public string Character { get; private set; }
        /// <summary>
        /// Create raw keyevent arguments.
        /// </summary>
        /// <param name="vkCode"></param>
        /// <param name="isSysKey"></param>
        /// <param name="character">Character</param>
        public RawKeyEventArgs(int vkCode, bool isSysKey, string character)
        {
            VKCode = vkCode;
            IsSysKey = isSysKey;
            Character = character;
            Key = KeyInterop.KeyFromVirtualKey(vkCode);
        }
    }
