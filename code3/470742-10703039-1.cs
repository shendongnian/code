     public void UncheckCheckBoxItems(CheckBoxList cbl)
     {
         foreach (ListItem item in CheckBoxList1.Items)
         {
             item.Selected = false;
         }
     }
