    private void tabControl1_MouseMove(object sender, MouseEventArgs e)
    {
        Rectangle mouseRect = new Rectangle(e.X, e.Y, 1, 1);
        for (int i = 0; i < tabControl1.TabCount; i++)
        {
            if (tabControl1.GetTabRect(i).IntersectsWith(mouseRect))
            {
                tabControl1.SelectedIndex = i;
                break;
            }
        }
    }
