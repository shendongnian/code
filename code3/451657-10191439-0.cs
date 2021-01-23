    if (dataTablerepeaterUserList.rows.count > 0)
    {
         ForEach(ListItem  itm  In ddlTitle.Items)
         {
                If (itm.Text = dataTablerepeaterUserList.Rows[0].tostring())
                {
                      itm.Selected = True;
                }
         }
    }
