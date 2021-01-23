    int btnPos = 1;
    Panel pnl = new Panel();
    pnl.AutoScroll = true;
    pnl.Top = 15;
    pnl.Left = 2;
    pnl.Width = groupBox1.Width - 8;
    for (int i = 0; i < 22; i++)
    {
        Button _btn = new Button();
        _btn.Text = "lbl";
        _btn.Top = btnPos;
        btnPos += 23;
        pnl.Controls.Add(_btn);
    }
    groupBox1.Controls.Add(pnl);
