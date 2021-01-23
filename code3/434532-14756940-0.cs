            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                RadComboBox  myCBO = (RadComboBox)item.FindControl("cboStatus")
                myCBO.Visible = false;
            }
