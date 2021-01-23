    protected void chkAssignAll_CheckedChanged(object sender, EventArgs e)
                {
                  
                    GridViewRow gr = (GridViewRow) ((DataControlFieldCell) ((CheckBox) sender).Parent).Parent;
                    CheckBox chk1 = (CheckBox) gr.FindControl("chkAssignSun");
                    CheckBox chk2 = (CheckBox) gr.FindControl("chkAssignMon");
                   
                    chk1.Checked = ((CheckBox) sender).Checked;
                    chk2.Checked = ((CheckBox)sender).Checked;                    
                }
