    try
    {
        Main_Box.BackColor = Color.FromArgb(Properties.Settings.Default.TCP_BackgroundR, Properties.Settings.Default.TCP_BackgroundG, Properties.Settings.Default.TCP_BackgroundB);
    }
    catch (ArgumentException)
    {
        //If a invalid color was read in from the config file use white instead
        Main_Box.BackColor = Color.White;
    }
