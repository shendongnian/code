    for (int i = 0; i < 5; i++)
    {
        int j = i; // Need to do this to fix closure issue
        Button buttonX = new Button();
        buttonX.Location = new Point(0, 0 + offset);
        buttonX.Size = new Size(310, 48);
        buttonX.Click += (sender, e) => {
            buttonClick(sender, e, j);
        };
    }
        
    private void buttonClick(object sender, EventArgs e, int i)
    {
        MessageBox.Show(i.toString());
    }
