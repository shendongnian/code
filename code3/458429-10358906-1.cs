    for (int i=0; i<= DataList1.Items.Count; i++)
    {
        if (e.Item[i] == dlDataList.Items.Count - 1) //This doesn't work like I'd hoped
         {
           Panel button = (Panel)e.Item.FindControl("btnButton");
            button.CssClass = ("altClass");
          }
    }
