    public bool PlayDataToEnd
    {
        get
        {
            return playDataToEndCombo.SelectedValue.ToString() == "Yes";
        }
        set
        {
            playDataToEndCombo.SelectedValue = value ? "Yes" : "No";
        }
    }
