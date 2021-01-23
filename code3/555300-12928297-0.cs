    foreach (DataListItem item in dtlstfilter.Items)
    {
      if (item.ItemType == ListItemType.Item)
      {
        CheckBoxList checkBox = item.FindControl("chklist") as CheckBoxList;
      }
    }
