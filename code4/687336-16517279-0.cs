    for (int i=0; i<tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.TabPages[i] == tabControl1.SelectedTab)
                {
                    tabControl1.TabPages[i].ImageIndex = i + tabControl1.TabPages.Count;
                }
                else
                {
                    tabControl1.TabPages[i].ImageIndex = i;
                }
            }
