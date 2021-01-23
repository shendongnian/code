            CheckBox activeCheckBox = sender as CheckBox;
            // to unckek all chek box
            foreach (GridViewRow rw in GrdProc.Rows)
            {
                CheckBox chkBx = (CheckBox)rw.FindControl("ChkCust");
                    if (chkBx != activeCheckBox )
                    {
                       chkBx.Checked = false;
                    }
            }
