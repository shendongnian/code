    if (e.Item.ItemType == ListViewItemType.DataItem)
    {
        foreach (Control c in e.Item.Controls) 
        {
            if (c is Label && c.ID.Contains("TWALabel"))
            {
                Label theTWALabel = (Label)c
                int theTWAValue = Convert.ToInt32(theTWALabel.Text);
                if (theTWAValue >= 85)
                {
                    if (theTWAValue < 90)
                    {
                        theTWALabel.CssClass = "YellowThis";
                    }
                    else
                    {
                        theTWALabel.CssClass = "RedThis";
                    }
                }            
            }
        }
    }
