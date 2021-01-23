        protected override void DestroyWindowCore(System.Runtime.InteropServices.HandleRef hwnd) {
            base.DestroyWindowCore(hwnd);// clean up handles
            // Disposing here prevents access violation from crashing non-debug instances
            // Confirmed to prevent access violation on WebCore shutdown as well
            webControl1.Dispose();
            webControl1 = null;
        }
        // This code seems to work in WinForms, I placed this in Form1.cs:
        protected override void DestroyHandle() {
            base.DestroyHandle();
            webControl1.Dispose();
        }
