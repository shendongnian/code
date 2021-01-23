        for (int x = 0; x < 3; x++)
        {
            UserControl1 uc = new UserControl1();
            TabPage tp = new TabPage();
            tp.Controls.Add(uc);
            this.TabControl1.TabPages.Add(tp);
        }
