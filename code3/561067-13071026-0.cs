        ToolTip     mTooltip;
        Point mLastPos = new Point(-1, -1);
        private void listview_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info    =   mLV.HitTest(e.X, e.Y);
            if (mLastPos != e.Location)
            {
                if (info.Item != null && info.SubItem != null)
                {
                    mTooltip.ToolTipTitle = info.Item.Text;
                    mTooltip.Show(info.SubItem.Text, info.Item.ListView, e.X, e.Y, 20000);
                }
                else
                {
                    mTooltip.SetToolTip(mLV, string.Empty);
                }
            }
            mLastPos = e.Location;
        }
