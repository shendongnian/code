        public Keys KeyCode { get; set; }
        public KeyPressedEventArgs(Keys Key)
        {
            KeyCode = Key;
        }
    }
 
    public delegate void KeyPressedEventHandler(KeyPressedEventArgs e);
    public delegate IntPtr KeyboardProcess(int nCode, IntPtr wParam, IntPtr lParam);
