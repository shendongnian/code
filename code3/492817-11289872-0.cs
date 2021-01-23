    using System;
    using System.Runtime.InteropServices;
    
    namespace WallpaperPathRetrieval
    {
        class Program
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern Int32 SystemParametersInfo(UInt32 action, 
                UInt32 uParam, string vParam, UInt32 winIni);
            private static readonly UInt32 SPI_GETDESKWALLPAPER = 0x73;
            private static uint MAX_PATH = 260;
    
            static void Main(string[] args)
            {
                string wallpaper = new string('\0', (int)MAX_PATH);
                SystemParametersInfo(SPI_GETDESKWALLPAPER, MAX_PATH, wallpaper, 0);
                
                wallpaper = wallpaper.Substring(0, wallpaper.IndexOf('\0'));
            }
        }
    }
