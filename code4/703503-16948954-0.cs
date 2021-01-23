You are getting the error because fileBytes only exists within the delegate passed to ForEach. Try this:
    private void executeSaveAttachment(object parameter)
    {
        using (var dlg = new SaveFileDialog())
        {
            foreach (var table in Table)
            {
                if (dlg.ShowDialog() ?? false)
                {
                    File.WriteAllBytes(dlg.FileName, table.Data)
                }
            }
        }
    }
