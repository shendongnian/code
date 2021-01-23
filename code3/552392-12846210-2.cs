    private void inputChanged(object sender, TextChangedEventArgs e)
    {
        double red, green, blue;
        if(Double.TryParse(txtRed.Text, out red) &&
            Double.TryParse(txtGreen.Text, out green) &&
            Double.TryParse(txtBlue.Text, out blue)) 
        {
            sldRed.Value = red;
            sldGreen.Value = green;
            sldBlue.Value = blue;
            changeColors(red, green, blue);
        }
    }
