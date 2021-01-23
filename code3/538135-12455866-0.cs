    object selectedItem;
    private void ComboboxSelectionChanged(...)
    {
         selectedItem = combobox.SelectedItem;
    }
    private void ButtonClickEventHanlder(...)
    {
        if(selectedItem == firstdatabase)
          //do this
        else if (selectedItem == seconddatabase)
          //do something else in the other db
        ...
    }
