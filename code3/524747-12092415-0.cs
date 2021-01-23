    foreach(ListItem listItem in lstFieldNames.Items)
    {
       if (listItem.Selected == True)
       {
          string val = listItem.Value;  //contains the value of the selected item
          string s = listItem.Text;      //is the text displayed in the listbox of the selected item
       }
    }
