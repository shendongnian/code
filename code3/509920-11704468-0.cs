    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      List<int> checkList = new List<int>();
      foreach (ListItem item in CheckBoxList1.Items)
      {
         if (item.Selected)
         {
            checkList.Add(1);
         }
         else
         {
            checkList.Add(0);
         }
        
         //Now you can use this list to pass it to Sql
      }
    }
