    protected void lsvActions_ItemDataBound(object sender, GridItemEventArgs e)
            {
    
    
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    RadComboBox  myCBO = (RadComboBox)item.FindControl("cboStatus")
    
                    myCBO.Visible = false;
    
                }
    }
