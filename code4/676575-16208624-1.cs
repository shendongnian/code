    foreach (TabPage page in quiztabs.TabPages) 
    {
        foreach (RadioButton rad in page.Controls.OfType<RadioButton>())
        {
            rad.Checked = false;
        }
        foreach (CheckBox chk in page.Controls.OfType<CheckBox>())
        {
            chk.Checked = false;
        }
    }
