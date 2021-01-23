    public Item SelectedItem
    {
      get
      {
        return selectedItem;
      }
      set
      {
        if (selectedItem != value)
        {
          if (selectedItem != null)
          {
            selectedItem.CurrentBackgroundColor = selectedItem.BackgroundColor;
          }
          selectedItem = value;
          if (selectedItem != null)
          {
            selectedItem.CurrentBackgroundColor = null;
          }
          RaisePropertyChanged("SelectedItem");
        }
      }
    }
