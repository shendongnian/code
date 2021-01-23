        [StructLayoutAttribute(LayoutKind.Sequential)]
        internal struct LV_COLUMN
        {
            public UInt32 mask;
            public Int32 fmt;
            public Int32 cx;
            public String pszText;
            public Int32 cchTextMax;
            public Int32 iSubItem;
            public Int32 iImage;
            public Int32 iOrder;
        }
        [DllImport("User32", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendLVColMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, ref LV_COLUMN lParam);
        internal const uint LVCF_FMT = 0x1;
        internal const uint LVCF_IMAGE = 0x10;
        internal const int LVCFMT_IMAGE = 0x800;
        internal const int LVCFMT_BITMAP_ON_RIGHT = 0x1000;
        // Get the old format flags
        col.mask = LVNative.LVCF_FMT;
        LVNative.SendLVColMessage(lvSessions.Handle, LVNative.LVM_GETCOLUMN, (UInt32)iCol, ref col);
        // Set the new format flags
        col.mask = LVNative.LVCF_FMT | LVNative.LVCF_IMAGE;
        col.fmt |= LVNative.LVCFMT_IMAGE | LVNative.LVCFMT_BITMAP_ON_RIGHT;
        col.iImage = (bAscending) ? (int)SessionIcons.SortAscending : (int)SessionIcons.SortDescending;
        LVNative.SendLVColMessage(lvSessions.Handle, LVNative.LVM_SETCOLUMN, (UInt32)iCol, ref col);
