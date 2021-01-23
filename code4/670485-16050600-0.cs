    class SafeCursorHandle : Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid {
        public SafeCursorHandle(IntPtr handle) : base(true) {
            base.SetHandle(handle);
        }
        protected override bool ReleaseHandle() {
            if (!this.IsInvalid) {
                if (!DestroyCursor(this.handle))
                    throw new System.ComponentModel.Win32Exception();
                this.handle = IntPtr.Zero;
            }
            return true;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyCursor(IntPtr handle);
    }
