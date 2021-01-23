    private void setZoneValues(Button button, string setting)  
    {
        // change button color
        button.BackColor = (button.BackColor == Color.Lime) ? 
                            Color.Tomato : Color.Lime;
        // set settings color
        Settings.Default.MyButtonColor = button.BackColor;
    }
