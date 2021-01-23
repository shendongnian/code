    //Method 1 fix by setting a default value.
    try
    {
        Main_Box.BackColor = Color.FromArgb(Properties.Settings.Default.TCP_BackgroundR, Properties.Settings.Default.TCP_BackgroundG, Properties.Settings.Default.TCP_BackgroundB);
    }
    catch (ArgumentException)
    {
        //If a invalid color was read in from the config file use white instead
        Main_Box.BackColor = Color.White;
    }
    //Method 2 fix by clamping values.
    int red = Math.Min(Math.Max(Properties.Settings.Default.TCP_BackgroundR, 0), 255);
    int green = Math.Min(Math.Max(Properties.Settings.Default.TCP_BackgroundG, 0), 255);
    int blue = Math.Min(Math.Max(Properties.Settings.Default.TCP_BackgroundB, 0), 255);
    Main_Box.BackColor = Color.FromArgb(red, green, blue);
