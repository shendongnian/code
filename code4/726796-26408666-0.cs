    private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        e.ItemHeight = (int)e.Graphics.MeasureString(lst.Items[e.Index].ToString(), lst.Font, lst.Width).Height;
    }
    private void lst_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        e.DrawFocusRectangle();
        e.Graphics.DrawString(lst.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
    }
