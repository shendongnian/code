    Button btn = sender as Button;
    if (btn == button1)
    {
        button1.Enabled = false;
        button2.Enabled = true;
        button3.Enabled = false;
        MessageBox.Show("button 1 is disabled");
    }
    else if (btn == button2)
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = true;
        MessageBox.Show("button 1 & button 2 are disabled");
    }
    else if (btn == button3)
    {
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
        MessageBox.Show("button 3 disabled");
    }
