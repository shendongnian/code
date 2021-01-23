        protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
        { 
            //Process checked item 
        }
        protected void chkAll_OnCheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow item in grdTest.Rows)
            {
                CheckBox ckb = (CheckBox)item.FindControl("chkSelect");
                //This will not call the individual event
                ckb.Checked = ((CheckBox)sender).Checked;
                //Process checked item 
            }
        }
