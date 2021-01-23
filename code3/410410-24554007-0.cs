    public class DimmableTabControl : TabControl
    {
        public DimmableTabControl()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            DrawItem += DimmableTabControl_DrawItem;
            Selecting += DimmableTabControl_Selecting;
        }
        private void DimmableTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = TabPages[e.Index];
            using(SolidBrush brush = new SolidBrush(page.Enabled ? page.ForeColor : SystemColors.GrayText))
            {
                e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds.X + 3, e.Bounds.Y + 3);
            }
        }
        private void DimmableTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }
    }
