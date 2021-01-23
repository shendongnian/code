    private void UpdateTextPosition()
    {
        Graphics g = this.CreateGraphics();
        Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
        Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
        String tmp = " ";
        Double tmpWidth = 0;
        while ((tmpWidth + widthOfASpace) < startingPoint)
        {
           tmp += " ";
           tmpWidth += widthOfASpace;
        }
        this.Text = tmp + this.Text.Trim();
    }
