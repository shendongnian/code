    if(!Button2.Enabled)
    {
        Timer1.Enabled = true;  // You might also have to reset its properties
        Button2.Text = "Disable automatic refresh";
        Button2.Font.Italic = false;
        Button2.Enabled = true;
    }
