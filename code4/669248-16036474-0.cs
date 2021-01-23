    public class ReportFile
    {
      public string Path { get; set; }
      public string FileName { get; set; }
    }
    
    private void buttonAttach_Click(object sender, RoutedEventArgs e)
    {
      Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
      if (dlg.ShowDialog() == true)
      {
        foreach (string str in dlg.FileNames)
        {
          ReportFile reportFile = new ReportFile();
          reportFile.Path = str;
          reportFile.FileName = System.IO.Path.GetFileName(str);
          dataGrid1.Items.Add(reportFile);
        }
      }
    }
    
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      foreach (ReportFile reportFile in dataGrid1.Items)
      {
        string fileName = @"C:\Temp\" + reportFile.FileName;
        if (File.Exists(fileName))
          continue;
        else
        {
          try
          {
            File.Copy(reportFile.Path, fileName);
          }
          catch (Exception err)
          {
            MessageBox.Show(err.Message);
            return;
          }
        }
      }
    }
