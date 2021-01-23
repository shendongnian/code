    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      ProcessStartInfo info = new ProcessStartInfo();
      info.FileName = "notepad";
      info.UseShellExecute = true;
      var process = Process.Start(info);
      Thread.Sleep(2000);
      SetParent(process.MainWindowHandle, this.Handle);
    }
