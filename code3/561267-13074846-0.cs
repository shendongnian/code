    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct HWND__ {
    
        /// int
        public int unused;
    }
    public partial class NativeMethods {
    
        /// Return Type: int
        ///hWnd: HWND->HWND__*
        ///lpText: LPCSTR->CHAR*
        ///lpCaption: LPCSTR->CHAR*
        ///uType: UINT->unsigned int
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint="MessageBoxA")]
        public static extern  int MessageBoxA([System.Runtime.InteropServices.InAttribute()] System.IntPtr hWnd, [System.Runtime.InteropServices.InAttribute()][System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpText, [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string lpCaption, uint uType) ;
    }
    public partial class NativeConstants {
    
        /// MB_SETFOREGROUND -> 0x00010000L
        public const int MB_SETFOREGROUND = 65536;
    
        /// MB_SYSTEMMODAL -> 0x00001000L
        public const int MB_SYSTEMMODAL = 4096;
    
        /// MB_ICONWARNING -> MB_ICONEXCLAMATION
        public const int MB_ICONWARNING = NativeConstants.MB_ICONEXCLAMATION;
    
        /// MB_OK -> 0x00000000L
        public const int MB_OK = 0;
    
        /// MB_ICONEXCLAMATION -> 0x00000030L
        public const int MB_ICONEXCLAMATION = 48;
    }
