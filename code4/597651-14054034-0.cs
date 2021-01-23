    void EmployeeFormView_ItemInserting(Object sender, FormViewInsertEventArgs e)
      {
    
        MessageLabel.Text = "";
    
        // Iterate through the items in the Values collection
        // and verify that the user entered a value for each 
        // text box displayed in the insert item template. Cancel
        // the insert operation if the user left a text box empty.
        foreach (DictionaryEntry entry in e.Values)
        {
          if (entry.Value.Equals(""))
          {
            // Use the Cancel property to cancel the 
            // insert operation.
            e.Cancel = true;
    
            MessageLabel.Text += "Please enter a value for the " +
              entry.Key.ToString() + " field.<br/>";
    
          }
        }
      }
