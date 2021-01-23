    private Task<int> previousTask = Task.FromResult(0);
    private async void MenuMediaAddFiles_OnClick(object sender, RoutedEventArgs e)
    {
        var dialog = GetDefaultOpenFileDialog();
        using (dialog)
        {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var progress = new SimpleProgress(this))
                {
                    previousTask = previousTask.ContinueWith(t =>
                        _context.AddFiles(dialog.FileNames, progress))
                        .UnWrap(); ;
                    int addFiles = await previousTask;
                    Console.WriteLine("Files added: {0}", addFiles);
                }
            }
        }
    }
