        void lstList_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = lstList.GetItemAt(e.X, e.Y);
            ListViewHitTestInfo info = lstList.HitTest(e.X, e.Y);
            if ((item != null) && (info.SubItem != null) && (info.SubItem.Tag == "mydecimal"))
            {
                toolTip1.SetToolTip(lstList, info.SubItem.Text.ToString("X"));
            }
            else
            {
                toolTip1.SetToolTip(lstList, "");
            }
        }
