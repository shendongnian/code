    Task task = new Task(() =>
            {
                gridView.Enabled = false;
                gridView.CopyToClipboard();
                gridView.Enabled = true;
            });
            task.Start();
