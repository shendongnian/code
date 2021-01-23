    public void SomeMethod()
    {
        int argbColor = (int)Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM","ColorizationColor", null);
        var color = System.Drawing.Color.FromArgb(argbColor);
        string hexadecimalColor = ConverterToHex(color);
    }
    
    private static String ConverterToHex(System.Drawing.Color c)
    {
        return String.Format("#{0}{1}{2}", c.R.ToString("X2"), c.G.ToString("X2"), c.B.ToString("X2"));
    }
