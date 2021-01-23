    public void WriteTextOnScreen(string text)
    {
        Label tempLabel = new Label();
        tempLabel.Text = text;
        tempLabel.Name = "";
        tempLabel.Location = new Point(10, 10);
        this.Controls.Add(tempLabel);
    }
