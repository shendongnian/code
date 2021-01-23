        private IEnumerable<TabPage> GetTabPages(string sSQL, string sTable, string sFirstItem)
        {
            // generate your tabs here
        }
        private void Init(TabControl tb, string sSQL, string sTable, string sFirstItem)
        {
            tb.SuspendLayout();
            foreach (TabPage tabPage in GetTabPages(sSQL, sTable, sFirstItem))
            {
                tb.Controls.Add(tabPage);
            }
            tb.ResumeLayout();
        }
