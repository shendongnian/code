      foreach (ListViewItem item in ListView.Items)
            {
                if (item.ItemType != ListViewItemType.DataItem)
                     continue;
 
                var rbl = (RadioButtonList)item.FindControl("RadioButtonList1");
                if (!string.IsNullOrEmpty(rbl.SelectedValue))
                     score += int.Parse(rbl.SelectedValue);
        }
