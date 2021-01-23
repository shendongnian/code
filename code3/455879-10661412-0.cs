    public class UserCursors
    {
        [Serializable]
        internal enum ImageType
        {
            Bitmap = 0,
            Icon = 1,
            Cursor = 2,
            EnhMetafile = 3,
        }
        [Serializable, Flags]
        internal enum LoadImageFlags
        {
            DefaultColor = 0x0,
            Monochrome = 0x1,
            Color = 0x2,
            CopyReturnOriginal = 0x4,
            CopyDeleteOriginal = 0x8,
            LoadFromFile = 0x10,
            LoadTransparent = 0x20,
            DefaultSize = 0x40,
            VgaColor = 0x80,
            LoadMap3DColors = 0x1000,
            CreateDibSection = 0x2000,
            CopyFromResource = 0x4000,
            Shared = 0x8000,
        }
        [DllImport("user32.dll")]
        static extern IntPtr LoadImage(IntPtr hinst, String lpszName, ImageType uType, Int32 cxDesired, Int32 cyDesired, LoadImageFlags fuLoad);
        public IntPtr hInst = IntPtr.Zero;
        public String lpszName;
        public Int32 width = 0;
        public Int32 height = 0;
        public string regKeyName = String.Empty;
        public bool Changed = false;
        public UserCursors()
        {
        }
        public UserCursors(string cursorLocation, string keyName)
        {
            hInst = LoadImage(IntPtr.Zero, cursorLocation, ImageType.Cursor, width, height, LoadImageFlags.LoadFromFile);
            lpszName = cursorLocation;
            regKeyName = keyName;
        }
    }
