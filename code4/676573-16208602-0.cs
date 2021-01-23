    foreach(TabPage t in quizTabs.TabPages)
    {
           foreach (RadioButton rad in t.Controls)
            {
                rad.Checked = false;
            }
            foreach (CheckBox chk in t.Controls)
            {
                chk.Checked = false;
            }
    }
