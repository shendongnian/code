        protected void chkSelect_OnCheckedChanged(object sender, EventArgs e)
        { 
            //Process item checked
        }
        protected void chkAll_OnCheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow item in grdTeste.Rows)
            {
                CheckBox ckb = (CheckBox)item.FindControl("chkSelect");
                //This will not call the individual event
                ckb.Checked = ((CheckBox)sender).Checked;
                //Process item checked
            }
        }
