    ucFactuur ucFactuur = new ucFactuur();
    ucFactuur.AutoSize = true;
    ucFactuur.Resize += DoResize;
    splitContainer1.Panel2.Resize += DoResize;
    splitContainer1.Panel2.AutoScroll = false;
    splitContainer1.Panel2.Controls.Add(ucFactuur);
