    public bool PlayDataToEnd
    {
        get
        {
            return playDataToEndCombo.SelectedIndex == 0;
        }
        set
        {
            playDataToEndCombo.SelectedIndex = value ? : 0 : 1;
        }
    }
