    private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
        // values
        TabControl tabCtrl = (TabControl)sender;
        Brush fontBrush = Brushes.Black;
        string title = tabCtrl.TabPages[e.Index].Text;
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Near;
        sf.LineAlignment = StringAlignment.Center;
        int indent = 3;
        Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y + indent, e.Bounds.Width, e.Bounds.Height - indent);
        // draw title
        e.Graphics.DrawString(title, tabCtrl.Font, fontBrush, rect, sf);
        // draw image if available
        if (tabCtrl.TabPages[e.Index].ImageIndex >= 0)
        {
            Image img = tabCtrl.ImageList.Images[tabCtrl.TabPages[e.Index].ImageIndex];
            float _x = (rect.X + rect.Width) - img.Width - indent;
            float _y = ((rect.Height - img.Height) / 2.0f) + rect.Y;
            e.Graphics.DrawImage(img, _x, _y);
        }
    }
