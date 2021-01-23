    protected void RadTreeList1_PreRender(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (TreeListDataItem item in RadTreeList1.Items)
            {
                if (item is TreeListDataItem)
                {
                    item.Edit = true;
                }
            }
            RadTreeList1.Rebind();
        }
    }
