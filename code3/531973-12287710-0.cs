    public void SelectList(string[] selectedText){
      foreach(string item in selectedText){
         CheckBoxList1.Items.FindByText(item).Selected = true;
         // User FindByValue in case of to find the item via value.
      }
    }
