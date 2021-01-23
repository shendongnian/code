    for(int counter = 1; counter < 10; counter++)
    {
        // Add new button
        Button btn = new Button();
        btn.Width = 250;
        btn.Height = 50;
        int num = counter;
        btn.Click += delegate (object sender1, EventArgs e1)
        { myEventHandler(sender1, e1, num ); };
        Test.Controls.Add(btn);
    }
    public void myEventHandler(object sender, EventArgs e, int i)
    {
        MessageBox.Show("Test: " + i);
    }
