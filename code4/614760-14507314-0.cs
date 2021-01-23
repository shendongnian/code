    // your TabControl will be defined in your designer
    TabControl tc;
    // as will your original TabPage
    TabPage tpOld;
    TabPage tpNew = new TabPage();
    tpNew.Controls.AddRange(tpOld.Controls);
    tc.TabPages.Add(tpNew);
