    async void buttonSaveClick(..)
    {
      buttonSave.Enabled = false;
      try
      {
        await myModel.Clone().SaveAsync();
      }
      catch (Exception ex)
      {
        // Display error.
      }
      buttonSave.Enabled = true;
    }
