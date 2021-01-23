    protected void grid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
           if (e.Item is GridEditableItem && e.Item.IsInEditMode)
           {
                GridEditableItem item = (GridEditableItem)e.Item;
                RadComboBox combo = ((RadComboBox)item.FindControl("RadComboBoxValore"));
                combo.DataSource = SqlDataSource2;
                combo.DataValueField = "EmployeeID";
                combo.DataTextField = "EmployeeID";
                combo.DataBind();   
            }
        }
