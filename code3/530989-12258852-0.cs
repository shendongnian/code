      bool check = DropDownList1.Items.Contains(new ListItem("name", "value"));
      if( check )
      {
          string t1 = DropDownList1.SelectedItem.ToString().Trim();
            CheckBoxList1.Items.Add(string.Concat(t1, i));
      }
      else
      {
          // again concatenate a new item 
        }
