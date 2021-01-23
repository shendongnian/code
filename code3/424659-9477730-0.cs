            string fileName = "";
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Name != fileName)
                {
                    tabControl1.TabPages.Add(filename);
                    break;
                }
                else
                {
                    tabControl1.SelectTab(tab.TabIndex);
                    break;
                }
            }
