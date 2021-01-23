    private Task previousTask = Task.FromResult(true);
    private object key = new object();
    private async void MenuMediaAddFiles_OnClick(object sender, RoutedEventArgs e)
    {
        var dialog = GetDefaultOpenFileDialog();
        using (dialog)
        {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var progress = new SimpleProgress(this))
                {
                    Task<int> nextTask;
                    lock (key)
                    {
                        nextTask = previousTask.ContinueWith(t =>
                            _context.AddFiles(dialog.FileNames, progress))
                            .UnWrap();
                        previousTask = nextTask;
                    }
                    int addFiles = await nextTask;
                    Console.WriteLine("Files added: {0}", addFiles);
                }
            }
        }
    }
