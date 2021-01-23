    private async void ShowProcessesButton_Click(object sender, EventArgs args)
    {
      while (true)
      {
        await Task.Delay(1000);  // TaskEx.Delay in the CTP
        YourListBox.Items.Clear();
        foreach (Process p in Process.GetProcesses())
        {
          YourListBox.Items.Add(p.ProcessName);
        }
      }
    }
