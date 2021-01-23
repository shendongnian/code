    public static List<string> GetScreenResolutions()
    {
        var resolutions = new List<string>();
        try
        {
            var devMode = new DEVMODE();
            int i = 0;
            while (EnumDisplaySettings(null, i, ref devMode))
            {
                resolutions.Add(string.Format("{0}x{1}", devMode.dmPelsWidth, devMode.dmPelsHeight));
                i++;
            }
            resolutions = resolutions.Distinct(StringComparer.InvariantCulture).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not get screen resolutions.");
        }
        return resolutions;
    }
    public static string GetCurrentScreenResolution()
    {
        int width = GetSystemMetrics(0x00);
        int height = GetSystemMetrics(0x01);
        return string.Format("{0}x{1}", width, height);
    }
