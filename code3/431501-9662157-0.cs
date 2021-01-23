    private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabCount - 1; i++)
            {
                if (tabControl1.GetTabRect(i).Contains(e.X, e.Y))
                {
                    tabControl1.SelectedIndex = i;
                }
            }
        }
