            string fileName = "";
            bool isPresent = false;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (tabControl1.TabPages[i].Name == filename)
                {
                    isPresent = true;
                    break;
                }
            }
            if (isPresent)
            {
                    tabControl1.TabPages.Add(filename);
            }
            else
            {
                    tabControl1.SelectTab(tab.TabIndex);
            }
