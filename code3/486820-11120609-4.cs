    protected void cmbCsvColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = ((DropDownList)(sender)).ClientID;
            for (int i = 0; i < rptTableMapper.Items.Count; i++)
            {
                DropDownList cmb = (DropDownList)(rptTableMapper.Items[i].FindControl("cmbCsvColumns"));
                ListItem selectedItem = ((DropDownList)(sender)).SelectedItem;
                if (cmb.ClientID != s)
                {
                    foreach (ListItem li in cmb.Items)
                    {
                        if (li.Value == selectedItem.Value)
                        {
                            cmb.Items.Remove(li);
                            break;
                        }
                    }
                }
            }
        }
