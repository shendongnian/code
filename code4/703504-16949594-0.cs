    private void executeSaveAttachment(object parameter)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                {
                    foreach (var table in Table)
                    {
                        if (dlg.ShowDialog() ?? false)
                        {
                            File.WriteAllBytes(dlg.FileName, table.Data);
                        }
                    }
                }
            }  
  
