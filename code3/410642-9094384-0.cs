    foreach (var item in ListBox.Items)
    {
       if (item.Text.Contains(stringToBeSearched))
       {
           //select item in the ListBox
           ListBox.SelectedValue = item.Value;
           break;
       }
    }
