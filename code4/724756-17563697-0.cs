    public class BrunoTabControl : TabControl
    {
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            if (ImageList == null) return;
            int imageIndex = TabPages[e.Index].ImageIndex;
            if (imageIndex >= 0) ImageList.Draw(e.Graphics, 0, 0, imageIndex);
        }
    }
