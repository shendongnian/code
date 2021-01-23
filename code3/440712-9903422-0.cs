    {
         foreach (DataListItem item in DataList.Items)
                    {
                        RadioButtonList RB = item.FindControl("RB") as RadioButtonList;
                        if(RB!=null && RB.SelectedValue!=null)
                    {
                        Label1.text=RB.SelectedValue //for testing purpose only
                    }
               }
