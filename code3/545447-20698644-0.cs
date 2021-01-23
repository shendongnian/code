        static void Main(string[] args)
        {
            // you can use any type of file supported by your windows installation.
            string path = @"c:\temp\whatever.pdf";
            using (Bitmap bmp = ExtractThumbnail(path, new Size(1024, 1024), SIIGBF.SIIGBF_RESIZETOFIT))
            {
                bmp.Save("whatever.png", ImageFormat.Png);
            }
        }
        public static Bitmap ExtractThumbnail(string filePath, Size size, SIIGBF flags)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");
            // TODO: you might want to cache the factory for different types of files
            // as this simple call may trigger some heavy-load underground operations
            IShellItemImageFactory factory;
            int hr = SHCreateItemFromParsingName(filePath, IntPtr.Zero, typeof(IShellItemImageFactory).GUID, out factory);
            if (hr != 0)
                throw new Win32Exception(hr);
            IntPtr bmp;
            hr = factory.GetImage(size, flags, out bmp);
            if (hr != 0)
                throw new Win32Exception(hr);
            return Bitmap.FromHbitmap(bmp);
        }
        [Flags]
        public enum SIIGBF
        {
            SIIGBF_RESIZETOFIT = 0x00000000,
            SIIGBF_BIGGERSIZEOK = 0x00000001,
            SIIGBF_MEMORYONLY = 0x00000002,
            SIIGBF_ICONONLY = 0x00000004,
            SIIGBF_THUMBNAILONLY = 0x00000008,
            SIIGBF_INCACHEONLY = 0x00000010,
            SIIGBF_CROPTOSQUARE = 0x00000020,
            SIIGBF_WIDETHUMBNAILS = 0x00000040,
            SIIGBF_ICONBACKGROUND = 0x00000080,
            SIIGBF_SCALEUP = 0x00000100,
        }
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHCreateItemFromParsingName(string path, IntPtr pbc, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IShellItemImageFactory factory);
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
        private interface IShellItemImageFactory
        {
            [PreserveSig]
            int GetImage(Size size, SIIGBF flags, out IntPtr phbm);
        }
