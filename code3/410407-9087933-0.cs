    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.tabPage2.Enabled = false; // no casting required.
            this.tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new DrawItemEventHandler(DisableTab_DrawItem);
        }
        private void DisableTab_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage page = tabControl.TabPages[e.Index];
            if (!page.Enabled)
            {
                using (SolidBrush brush = new SolidBrush(SystemColors.GrayText))
                {
                    e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds.X + 3, e.Bounds.Y + 3);
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(page.ForeColor))
                {
                    e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds.X + 3, e.Bounds.Y + 3);
                }
            }
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
                e.Cancel = true;
        }
    }
