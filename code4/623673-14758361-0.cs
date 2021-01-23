     TabPage tb = new TabPage("Tab");
        MenuStrip ms = new MenuStrip();
        ms.Items.Add("Add");
        ms.items[0].Click += new EventHandler(AddMenu_Click);
        tb.Controls.Add(ms);
        tb.Controls.Add(new UserControl(tabControl1)); //If you need to update tab text
          tabControl1.TabPages.Add(tb);
