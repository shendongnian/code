        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            LinkButton btn1 = (LinkButton)e.Item.FindControl("LinkButton1");
            var approveDeny = false;
            ListViewDataItem dataItem = (ListViewDataItem)e.Item;
            System.Boolean.TryParse(DataBinder.Eval(dataItem.DataItem, "ApproveOrDeny").ToString(), out approveDeny);
            if (approveDeny)
            {
                btn1.BackColor = System.Drawing.Color.Green;
                btn1.BackColor = System.Drawing.Color.Transparent;
            }
            else if (!approveDeny)
            {
                btn1.BackColor = System.Drawing.Color.Blue;
                btn1.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                btn1.BackColor = System.Drawing.Color.Red;
                btn1.BackColor = System.Drawing.Color.Transparent;
            }
        }
    }
