     public void UncheckCheckBoxItems(CheckBoxList cbl)
     {
         foreach (ListItem item in cbl.Items)
         {
             item.Selected = false;
         }
     }
