    // To count checklist item
      int a = ChkMonth.Items.Count;
            int count = 0;
            for (var i = 0; i < a; i++)
            {
                if (ChkMonth.Items[i].Selected == true)
                {
                    count++;
                }
            }
            
      // To access checkbox list item's value //
       string YrStrList = "";
            foreach (ListItem listItem in ChkMonth.Items)
            {
                if (listItem.Selected)
                {
                    YrStrList = YrStrList + "'" + listItem.Value + "'" + ",";
                }
            }
            sMonthStr = YrStrList.ToString();
