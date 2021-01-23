    for (int i = 0; i < 5; i++)
    {   
        Button buttonX = new Button();
        buttonX.Location = new Point(0, 0 + offset);
        buttonX.Size = new Size(310, 48);
        buttonX.Click += new EventHandler(buttonClick);
        buttonX.Tag = i;
    }
    private void buttonClick(object sender, EventArgs e)
    {
        MessageBox.Show(buttonX.Tag.ToString());
    }
