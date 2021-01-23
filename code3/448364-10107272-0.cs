    ucFactuur ucFactuur = new ucFactuur();
    ucFactuur.Location = new Point(
      splitContainer1.Panel2.ClientSize.Width / 2 - ucFactuur.Size.Width / 2,
      splitContainer1.Panel2.ClientSize.Height / 2 - ucFactuur.Size.Height / 2);
    ucFactuur.Anchor = AnchorStyles.None;
    splitContainer1.Panel2.Controls.Add(ucFactuur);
    splitContainer1.Panel2.AutoScrollMinSize = ucFactuur.Size;
