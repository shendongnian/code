    class Manager
    {
      private static Form1 _progressForm;
      public async Task GoAsync()
      {
        var owner = new Win32Window(Process.GetCurrentProcess().MainWindowHandle);
        _progressForm = new Form1();
        _progressForm.Show(owner);
        var progress = new Progress<int>(value => _progressForm.UpdateProgress(value));
        await Go(progress);
        _progressForm.Hide();
      }
      private Task<bool> Go(IProgress<int> progress)
      {
        return Task.Run(() =>
        {
          var job = new LongJob();
          job.Spin(progress);
          return true;
        });
      }
    }
    class LongJob
    {
      public void Spin(IProgress<int> progress)
      {
        for (var i = 1; i <= 100; i++)
        {
          Thread.Sleep(25);
          if (progress != null)
          {
            progress.Report(i);
          }
        }
      }
    }
