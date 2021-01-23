    protected void brandList_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Category mydata = (Category)dataItem.DataItem;
            int CurrentCategoryId = mydata.CategoryID;
            var query = _db.Products.Where(p => p.Category.CategoryID == CurrentCategoryId).Select(p => p.Brand).Distinct();
            ListView brandList = e.Item.FindControl("brandList");
            brandList.DataSource = query.ToList<Brand>();
            brandList.DataBound();
        }
    }
