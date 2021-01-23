       currentIndex = 0; //global initial setting
       tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
    
       void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
       {
           tabControl1.SelectedIndex = currentIndex;
           return;
       }
       private void nextButton_Click(object sender, EventArgs e)
       {
           currentIndex += 1;
           if (currentIndex >= tabControl1.TabPages.Count)
           {
               currentIndex = 0;
           }
           foreach (TabPage pg in tabControl1.TabPages)
           {
               pg.Enabled = false;
           }
           tabControl1.TabPages[currentIndex].Enabled = true;
           tabControl1.SelectedIndex = currentIndex;
       }
