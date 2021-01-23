    class SafeIconHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyIcon(
            [In] IntPtr hIcon);
    
        private SafeIconHandle()
            : base(true)
        {
        }
        public SafeIconHandle(IntPtr hIcon)
            : base(true)
        {
            this.SetHandle(hIcon);
        }
    
        protected override bool ReleaseHandle()
        {
            return DestroyIcon(this.handle);
        }
    }
