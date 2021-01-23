    protected void rep_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
             
                /////////////
                //logic for source_value
                /////////////
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    yourObj obj = (yourObj)e.Item.DataItem;
                    if (yourObj.source_value == 4)
                    {
                        dd.Items.Add("one");
                        dd.Items.Add("two");
                        dd.Items.Add("three");
                        dd.Items.Add("four");
                    }
                }
    
            }
