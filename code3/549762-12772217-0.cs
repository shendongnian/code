    TabPage _ClickedTab;
        public Form1()
        {
            InitializeComponent();
            this.tabControl1.MouseClick += new MouseEventHandler(tabControl1_MouseClick);
            
        }
        void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.tabControl1, e.Location);
                
                
                Rectangle r2 = this.tabControl1.GetTabRect(0);
                foreach (TabPage item in this.tabControl1.TabPages)
                {
                    Rectangle r = this.tabControl1.GetTabRect(tabControl1.TabPages.IndexOf(item));
                    if (r.X < e.Location.X && e.Location.X < r.X + r.Width && r.Y < e.Location.Y && e.Location.Y < r.Y + r.Height)
                    {
                        _ClickedTab = item;
                    }
                }
               
            }
        }
        
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Remove(_ClickedTab);
        }
