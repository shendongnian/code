    private static WMPLib.WindowsMediaPlayer Player;
    public static void VolumeUp()
    {
        if (Player.settings.volume < 90)
        {
            Player.settings.volume = (Player.settings.volume + 10);
        }
    }
    public static void VolumeDown()
    {
        if (Player.settings.volume > 1)
        {
            Player.settings.volume = (Player.settings.volume - (Player.settings.volume / 2));
        }
    }
