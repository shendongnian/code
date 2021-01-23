    string currClass =  hc.Attributes["class"].ToString();
    string count = e.Item.Controls.Count.ToString();
            if (e.Item.ItemIndex == 0)
                        {
                            currClass += " TabbedPanelsTabSelected";
                        }
         else if (e.Item.ItemIndex.ToString() == count)
                        {
                            currClass += " last";
                        }
