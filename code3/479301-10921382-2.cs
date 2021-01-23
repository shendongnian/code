    private void OnProcessExited(object sender, EventArgs e)
    {
      if (_process != null)
      {
        Thread.Sleep(2000);
        _process.CancelOutputRead();
        _process.CancelErrorRead();
        _process.Start();
        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();
      }
    }
