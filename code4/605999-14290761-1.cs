      protected void EmployeesListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
      {
        if (String.Equals(e.CommandName, "AddToList"))
        {
          // Verify that the employee ID is not already in the list. If not, add the
          // employee to the list.
          ListViewDataItem dataItem = (ListViewDataItem)e.Item;
          string employeeID = 
            EmployeesListView.DataKeys[dataItem.DisplayIndex].Value.ToString();
    
          if (SelectedEmployeesListBox.Items.FindByValue(employeeID) == null)
          {
            ListItem item = new ListItem(e.CommandArgument.ToString(), employeeID);
            SelectedEmployeesListBox.Items.Add(item);
          }
        }
      }
