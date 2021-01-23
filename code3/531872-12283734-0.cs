        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            UpdateUI(e.TabPageIndex);    
        }
        public void UpdateUI(int index)
        {
            switch (index)
            { 
                case 0:
                    treeView1.Enabled = true;
                    break;
                case 1:
                    treeView1.Enabled = false;
                    break;
                case 2:
                    treeView1.Enabled = false;
                    break;
                default:
                    treeView1.Enabled = false;
                    break;
            }
        }
 
