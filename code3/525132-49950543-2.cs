    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            [DllImport("User32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool IsClipboardFormatAvailable(uint format);
            [DllImport("User32.dll", SetLastError = true)]
            private static extern IntPtr GetClipboardData(uint uFormat);
            [DllImport("User32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool OpenClipboard(IntPtr hWndNewOwner);
            [DllImport("User32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseClipboard();
            [DllImport("Kernel32.dll", SetLastError = true)]
            private static extern IntPtr GlobalLock(IntPtr hMem);
            [DllImport("Kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool GlobalUnlock(IntPtr hMem);
            const uint CF_DIBV5 = 17;
            enum BitmapCompressionMode : uint
            {
                BI_RGB = 0,
                BI_RLE8 = 1,
                BI_RLE4 = 2,
                BI_BITFIELDS = 3,
                BI_JPEG = 4,
                BI_PNG = 5
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct BITMAPV5HEADER
            {
                public uint bV5Size;
                public int bV5Width;
                public int bV5Height;
                public UInt16 bV5Planes;
                public UInt16 bV5BitCount;
                public uint bV5Compression;
                public uint bV5SizeImage;
                public int bV5XPelsPerMeter;
                public int bV5YPelsPerMeter;
                public UInt16 bV5ClrUsed;
                public UInt16 bV5ClrImportant;
                public UInt16 bV5RedMask;
                public UInt16 bV5GreenMask;
                public UInt16 bV5BlueMask;
                public UInt16 bV5AlphaMask;
                public UInt16 bV5CSType;
                public IntPtr bV5Endpoints;
                public UInt16 bV5GammaRed;
                public UInt16 bV5GammaGreen;
                public UInt16 bV5GammaBlue;
                public UInt16 bV5Intent;
                public UInt16 bV5ProfileData;
                public UInt16 bV5ProfileSize;
                public UInt16 bV5Reserved;
            }
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct RGBQUAD
            {
                public byte rgbBlue;
                public byte rgbGreen;
                public byte rgbRed;
                public byte rgbReserved;
            }
            public MainWindow()
            {
                InitializeComponent();
                AttemptConversion();
            }
            private void AttemptConversion()
            {
                WindowInteropHelper helper = new WindowInteropHelper(this);
                bool gotIt = OpenClipboard(helper.Handle);
                if (!gotIt) return;
                bool formatAvail = IsClipboardFormatAvailable(CF_DIBV5);
                if (!formatAvail) return;
                IntPtr hBitmap = IntPtr.Zero;
                hBitmap = GetClipboardData(CF_DIBV5);
                IntPtr ptr = GlobalLock(hBitmap);
                BitmapSource bmpSrc = CF_DIBV5ToBitmapSource(hBitmap);
                img.Width = (int)bmpSrc.Width;
                img.Height = (int)bmpSrc.Height;
                img.Source = bmpSrc;
                if (ptr != IntPtr.Zero) GlobalUnlock(hBitmap);
                if (gotIt) CloseClipboard();
            }
            private BitmapSource CF_DIBV5ToBitmapSource(IntPtr hBitmap)
            {
                IntPtr scan0 = IntPtr.Zero;
                var bmi = (BITMAPV5HEADER)Marshal.PtrToStructure(hBitmap, typeof(BITMAPV5HEADER));
                int stride = (int)(bmi.bV5SizeImage / bmi.bV5Height);
                long offset = bmi.bV5Size + bmi.bV5ClrUsed * Marshal.SizeOf<RGBQUAD>();
                if (bmi.bV5Compression == (uint)BitmapCompressionMode.BI_BITFIELDS)
                {
                    offset += 12; //bit masks follow the header
                }
                scan0 = new IntPtr(hBitmap.ToInt32() + offset);
                BitmapSource bmpSource = BitmapSource.Create(
                    bmi.bV5Width, bmi.bV5Height,
                    bmi.bV5XPelsPerMeter, bmi.bV5YPelsPerMeter,
                    PixelFormats.Bgra32, null,
                    scan0, (int)bmi.bV5SizeImage, stride);
                return bmpSource;
            }
        }
    }
