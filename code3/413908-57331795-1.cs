    foreach(var item in yourListFromDB)
    {
     ListItem listItem = new ListItem();
     listItem.Text = item.name;
     listItem.Value = Convert.ToString(item.value);
     listItem.Selected=item.isSelected;                 
      checkedListBox1.Items.Add(listItem);
    }
    checkedListBox1.DataBind();
