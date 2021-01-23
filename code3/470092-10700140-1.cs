    protected void ResultsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Panel PlaceHolder1 = (Panel)e.Item.FindControl("PlaceHolder1");
                
                // declare/obtain the value of i given the DataItem
                // e.g.,
                int i = ((int)e.Item.DataItem); // or however you're getting i
                if (i == 1)
                {
                    var uc = LoadControl("~/DraftList.ascx");
                    PlaceHolder1.Controls.Add(uc);
                }
                else if (i == 2)
                {
                    var uc = LoadControl("~/FinalList.ascx");
                    PlaceHolder1.Controls.Add(uc);
                }
            }
        }
