    string[] days = "sun,mon,tue,thu,fri,sat".Split(',');
    ListItem[] chkdays = new ListItem[chks.Items.Count];
    chks.Items.CopyTo(chkdays, 0);
    chkdays.ToList().ForEach(delegate(ListItem item)
           {
               item.Selected = days.Contains(item.Text);
           });
