        UserControl1 myusercontrol = new UserControl1();
        public void TabClose(Object sender,EventArgs e)
        {
            int i = 0;
            i = tabControl1.SelectedIndex;
            tabControl1.TabPages.RemoveAt(i);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myusercontrol.Dock = DockStyle.Fill;
            TabPage myTabPage = new TabPage();
            myTabPage.Text = "Student";
            myTabPage.Controls.Add(myusercontrol);
            tabControl1.TabPages.Add(myTabPage);
            myusercontrol.OkClick += TabClose;
            
        }
