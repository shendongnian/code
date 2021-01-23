    async void AddButton_Click(..)
    {
      addButton.IsEnabled = false;
      await Save();
      AddToListView();
      addButton.IsEnabled = true;
    }
