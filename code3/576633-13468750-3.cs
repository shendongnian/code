      protected void Button1_Click(object sender, EventArgs e)
      {
            foreach (GridViewRow gvRow in gvTemp.Rows)
            {
                Repeater repeater = (Repeater)gvRow.FindControl("repeater1");
                foreach (RepeaterItem repItem in repeater.Items)
                {
                    RadioButtonList rbList = (RadioButtonList)repItem.FindControl("radiobuttonlist1");
                    foreach (ListItem item in rbList.Items)
                    {
                        if (item.Selected)
                        {
                            //code for selected items goes here...
                        }
                        else
                        {
                            //code for not selected items goes here...
                        }
                        if (item.Value == "0")
                        { 
                            //code for items with value == "0" goes here...
                        }
                        if (item.Value == "1")
                        {
                            //code for items with value == "1" goes here...
                        }
                    }
                }
            }
      }
