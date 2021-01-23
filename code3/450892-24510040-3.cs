    foreach(Listitem li in CheckBoxList1.Items)
    {
      if (li.Selected)
      {
        NewsItem.Isdraft = 1;
      }
    }
