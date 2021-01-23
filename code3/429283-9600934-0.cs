    using System;
    using System.Runtime.InteropServices;
    
    namespace GetFileTypeAndDescription
    {
    
    class Class1
    {
    [STAThread]
    static void Main(string[] args)
    {
    SHFILEINFO shinfo = new SHFILEINFO();
    IntPtr i = Win32.SHGetFileInfo(@"d:\temp\test.xls", 0, ref
    shinfo,(uint)Marshal.SizeOf(shinfo),Win32.SHGFI_TY PENAME);
    string s = Convert.ToString(shinfo.szTypeName.Trim());
    Console.WriteLine(s);
    }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
    public IntPtr hIcon;
    public IntPtr iIcon;
    public uint dwAttributes;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string szDisplayName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    public string szTypeName;
    };
    
    class Win32
    {
    public const uint SHGFI_DISPLAYNAME = 0x00000200;
    public const uint SHGFI_TYPENAME = 0x400;
    public const uint SHGFI_ICON = 0x100;
    public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
    public const uint SHGFI_SMALLICON = 0x1; // 'Small icon
    
    [DllImport("shell32.dll")]
    public static extern IntPtr SHGetFileInfo(string pszPath, uint
    dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
    }
    }
