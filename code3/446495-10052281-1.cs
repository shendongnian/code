    protected void DataList1_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {
     if (String.Equals(e.CommandName, "Validate"))
     {
      ListViewDataItem dataItem = (ListViewDataItem)e.Item;
      RadioButton rbtn1 = (RadioButton)dataItem.FindControl("RadioButton1");
      RadioButton rbtn2 = (RadioButton)dataItem.FindControl("RadioButton2");
      RadioButton rbtn3 = (RadioButton)dataItem.FindControl("RadioButton3");
      RadioButton rbtn4 = (RadioButton)dataItem.FindControl("RadioButton4");
      
      // Code to check which radio button was checked
     }
    }
