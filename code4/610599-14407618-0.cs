    async void runCheckedTasks_Click(object sender, EventArgs e)
    {
      var button = sender as Button;
      if (button == null) return;
      checkListBox.Enabled = false;
      button.Enabled = false;
      button.Text = "Running...";
      var items = checkListBox.CheckedIndices;
      await DoCheckedTasks(items);
      checkListBox.Enabled = true;
      button.Enabled = true;
      button.Text = "Go!";
    }
    async Task DoCheckedTasks(CheckedListBox.CheckedIndexCollection indicies)
    {
      foreach (int i in indicies)
      {
        // Here you cast to whatever type you are storing in the CheckListBox.
        // I am only using strings like 'First Task', 'Second Task', ...
        var item = checkListBox.Items[i] as string;
        checkListBox.Items[i] = string.Format("Processing {0}...", item);
        checkListBox.SetItemCheckState(i, CheckState.Indeterminate);
        var result = await DoTask(i);
        if(!result)
          checkListBox.Items[i] = string.Format("{0} Failed!", item);
        else
          checkListBox.Items[i] = string.Format("{0} Successful!", item);
        checkListBox.SetItemCheckState(i, CheckState.Unchecked);
      }
    }
    async Task<bool> DoTask(int index)
    {
      await Task.Delay(3000); // Fake Delay to simulate processing
      return true;
    }
