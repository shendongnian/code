    protected void DataList1_OnItemCommand(object sender, DataListCommandEventArgs e)
    {
     if (String.Equals(e.CommandName, "Validate"))
     {
      DataListItem dataItem = (DataListItem )e.Item;
      RadioButton rbtn1 = (RadioButton)dataItem.FindControl("RadioButton1");
      RadioButton rbtn2 = (RadioButton)dataItem.FindControl("RadioButton2");
      RadioButton rbtn3 = (RadioButton)dataItem.FindControl("RadioButton3");
      RadioButton rbtn4 = (RadioButton)dataItem.FindControl("RadioButton4");
      
      // Code to check which radio button was checked.
      if(rbtn1 != null && rbtn1.Checked)
      {
        
      }
      else if(rbtn2 != null && rbtn2.Checked)
      {
      } //Perform these for the remaining two check boxes
     }
    }
