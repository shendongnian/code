    private void DoResize(object sender, EventArgs e) {
      splitContainer1.Panel2.AutoScrollMinSize = ucFactuur.Size;
      if (ucFactuur.Width < splitContainer1.Panel2.ClientSize.Width) {
        ucFactuur.Left = splitContainer1.Panel2.ClientSize.Width / 2 -
                         ucFactuur.Width / 2;
      } else {
        ucFactuur.Left = splitContainer1.Panel2.AutoScrollPosition.X;
      }
      if (ucFactuur.Height < splitContainer1.Panel2.ClientSize.Height) {
        ucFactuur.Top = splitContainer1.Panel2.ClientSize.Height / 2 -
                        ucFactuur.Height / 2;
      } else {
        ucFactuur.Top = splitContainer1.Panel2.AutoScrollPosition.Y;
      }
    }
