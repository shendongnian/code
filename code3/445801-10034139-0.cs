    protected void vmbGID_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddlCtrl = sender as RadComboBox;
        if (ddlCtrl != null)
        {
            var dataItem = ddlCtrl.Parent as GridDataItem;
            if (dataItem != null)
            {
                var txtCtrl = dataItem.FindControl("txtValue") as RadTextBox;
                if (txtCtrl != null)
                {
                    txtCtrl.Text = ddlCtrl.SelectedValue;
                }
            }
        }
    }
