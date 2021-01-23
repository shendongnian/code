    private void button1_Click(object sender, EventArgs e)
    {
        TabPage tp = new TabPage();
        tp.Name = tabPage1.Name;
        var temp =tabControl1.Controls.Find(tp.Name,true);
        if( temp.Length > 0)
        {
            tabControl1.SelectedTab = (TabPage) temp[0];
        }
        else
            tabControl1.Controls.Add(tp);
    }
