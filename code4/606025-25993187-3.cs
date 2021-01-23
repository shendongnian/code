    //MinimumVolume
    [Description("When using a sound card for MIDI output use this to adjust the minimum volume.\r\n" +
    "Set this to zero for output to play back expression as it was recorded."),
    DisplayName("Minimum Volume"),
    Editor(typeof(UpDownValueEditor), typeof(UITypeEditor)),
    Category("MIDI")]
    public UInt16 MinimumVolume { get { return Settings.MinimumVolume; } set { Settings.MinimumVolume = value; } }
