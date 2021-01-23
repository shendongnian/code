    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern Int32 SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, String         pvParam, UInt32 fWinIni);
            private static UInt32 SPI_SETDESKWALLPAPER = 20;
            private static UInt32 SPIF_UPDATEINIFILE = 0x1;
            private static String imageFileName = "c:\\test\\test.bmp";
    
            static void Main(string[] args)
            {
                SetImage(imageFileName);
                Console.ReadKey();
            }
    
            private static void SetImage(string filename)
            {
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename, SPIF_UPDATEINIFILE);
            }
        }
    }
