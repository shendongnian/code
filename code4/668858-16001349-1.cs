    foreach (var selected in startupinfo.SelectedItems)
    {
      string s = selected.ToString();
      if (startupinfoDict.ContainsKey(s))
      {
        Process process = Process.Start(startupinfoDict[s]);
          process.WaitForExit();
          while (!process.HasExited)
              Thread.Sleep(500);
          Xceed.Wpf.Toolkit.MessageBox.Show("It works woho");
      }
    }
