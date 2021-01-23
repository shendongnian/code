    var process = new Process();
    process.startInfo = new ProcessStartInfo(Path.GetFullPath(filename));
    process.EnableRaisingEvents = true;
    process.Exited += (a, b) =>
    {
      MessageBox.Show("closed!");
    };
    process.Start();
