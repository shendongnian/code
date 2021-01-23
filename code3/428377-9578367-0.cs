    string[] str = e.CommandArgument.ToString().Split(';');
    int index = Convert.ToInt32(str[2]); // ur item selected index
    DataListItemCollection xx = DataList1.Items;
    int count = 0;
    foreach (DataListItem x in xx)
    {
      if (count == index)
        {
          (x.FindControl("Item") as LinkButton).BorderColor = System.Drawing.Color.Red;
          (x.FindControl("Item") as LinkButton).BorderWidth = 1;
        }
      else
        {
          (x.FindControl("Item") as LinkButton).BorderColor = System.Drawing.Color.White;
          (x.FindControl("Item") as LinkButton).BorderWidth = 0;
        }
     count = count + 1;
    }
