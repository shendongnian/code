    private void tabControl1_Selected(Object sender, TabControlEventArgs e) 
        {
            //could be initialized in "Form_Load"
            var validTabPages = new[] 
            {
                tabPage1,
                tabPage2,
                tabPage3,
                tabPage4
            };
            //if not a valid TabPage, just return
            if (!validTabPages.Contains(e.TabPage))
                return;
            pictureBox2.Parent.Controls.Remove(pictureBox2);
            pictureBox5.Parent.Controls.Remove(pictureBox5);
            e.TabPage.Controls.Add(pictureBox2);
            e.TabPage.Controls.Add(pictureBox5);
        }
