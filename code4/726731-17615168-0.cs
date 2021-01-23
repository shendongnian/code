        List<GridDataItem> Items = (from item in RadGrid1.MasterTableView.Items.Cast<GridDataItem>()
                                    where item.Selected
                                    select item).ToList();
        if (Items != null && Items.Count > 0)
        {
            foreach (GridDataItem item in Items)
            {
                string strUsername = item["UserName"].Text;
            }
        }
