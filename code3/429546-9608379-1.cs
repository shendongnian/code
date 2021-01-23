    foreach (DataListItem DLItem in DataList1.Items)
    {
       //unhighlight all ilnkbuttons
       LinkButton unHighLight = ((LinkButton)(DLItem.FindControl("Item")));
       if (unHighLight != null)
       {
        unHighLight.BackColor = System.Drawing.Color.Transparent;
       }
     }
    LinkButton highlighted = ((LinkButton)(e.Item.FindControl("Item")));
    highlighted.BackColor = System.Drawing.Color.Yellow;
