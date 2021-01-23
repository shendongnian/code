    protected void cbxAttributescheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            string CurrentCbxId = ((CheckBox)sender).ClientID;
            foreach (GridViewRow Row in gvAttributes.Rows)
            {
                RequiredFieldValidator rfvAttributeType = (RequiredFieldValidator)Row.FindControl("rfvAttributeType");
                if (((CheckBox)Row.FindControl("cbxAttributescheck")).ClientID.Equals(CurrentCbxId))
                {
                    rfvAttributeType.Enabled = cbx.Checked;
                }            
            }
        }
