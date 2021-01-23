    protected void RadGrid1_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
                    {
                      try
                    {
                      GridEditableItem editedItem = e.Item as GridEditableItem;
                      RadioButtonList JAN = (RadioButtonList)editedItem.FindControl("JAN");
                      
                     **// add below code**
                      if(JAN==null)
                      {
                         // print some error message..
                         return;
                       }
                           
                       string GENDER = JAN.SelectedValue;
                       foreach (ListItem item in JAN.Items)
                       { 
                         if (item.Selected)
                       {
                          GENDER = item.Value;
                        } 
                      } 
                      SqlConnection conn1 = BusinessTier.getConnection();
                      conn1.Open();
                      int flg = BusinessTier.SavePersonalInfo(conn1, 1,JAN.SelectedItem.Value,)
                      BusinessTier.DisposeConnection(conn1);
