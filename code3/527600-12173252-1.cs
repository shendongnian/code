    YourValues = new StringBuilder();
    foreach (DataListItem item in myDataList.Items)
    {
       var myCheckBox = (CheckBox)item.FindControl ("myCheckBoxId");
       if(myCheckBox.Selected)
       {
         YourValues.Append(myCheckBox.Text);
       }
    }
