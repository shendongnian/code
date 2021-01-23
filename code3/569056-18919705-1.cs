    CheckBox activeCheckBox = sender as CheckBox;
    // to uncheck all check box
    foreach (GridViewRow rw in GrdProc.Rows)
    {
        CheckBox chkBx = (CheckBox)rw.FindControl("ChkCust");
        if (chkBx != activeCheckBox )
        {
           chkBx.Checked = false;
        }
    }
