    public void Test(int value)
    {
        Properties.Settings settings = Properties.Settings.Default;
        MessageBox.Show("Last SliderWidth = " + settings.SliderWidth.ToString());
        settings.SliderWidth = value;
        settings.Save();
    }
