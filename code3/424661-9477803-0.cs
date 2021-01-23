            bool found = false;
            foreach (TabPage tab in tabControl1.TabPages) {
                if (filename.Equals(tab.Name)) {
                    tabControl1.SelectedTab = tab;
                    found = true;
                }
            }
            if( ! found)
                    tabControl1.TabPages.Add(filename,filename);
