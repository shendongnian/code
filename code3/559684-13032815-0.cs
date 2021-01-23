    public void ValueChanged()
    {
        var stringSize = e.Graphics.MeasureString(textBox.Text, textBox.Font);
        if(stringSize.Height > MAXSTRINGHEIGHT)
        {
           textBox.Text = TrimTextAndAddEllipsis(textBox.Text);
        }
    }
