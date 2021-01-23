    foreach(TabPage tp in quizTabs.TabPages)
         {
            foreach (RadioButton rad in tp.Controls)
            {
                rad.Checked = false;
            }
            foreach (CheckBox chk in tp.Controls)
            {
                chk.Checked = false;
            }
        }
