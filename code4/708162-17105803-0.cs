    public void SelectItems()
    {
     ListBox1.SelectionMode = ListSelectionMode.Multiple;
     var userinfos = AppDataAccess.retrieveUsers(id);
     var val = userInfos.Rows.SelectMany(r=>r["GroupNumber"].ToString().Split(','))
        .Distinct().ToList()
      //loop to select multiple items // could also be converted to Linq. Not sure it would be useful
      foreach (string per in val)
          {
           if (ListBox1.Items.FindByValue(per.ToString()) != null)
              {
               ListBox1.Items.FindByValue(per.ToString()).Selected = true;
               }
            }
   }
