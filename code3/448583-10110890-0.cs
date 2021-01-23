    [DllImport("c:\\USBPD.DLL")]
    private static extern int WriteText([In] byte[] text, int length);
    
    public static int WriteText(string text)
    {
        Encoding enc = Encoding.GetEncoding(437); // 437 is the original IBM PC code page
        byte[] bytes = enc.GetBytes(text);
        return WriteText(bytes, bytes.Length);
    }
