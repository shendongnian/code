    foreach(TabPage tp in quizTabs.TabPages)
         {
            foreach (RadioButton rad in tp.Controls.OfType<RadioButton>())
            {
                rad.Checked = false;
            }
            foreach (CheckBox chk in tp.Controls.OfType<CheckBox>())
            {
                chk.Checked = false;
            }
        }
