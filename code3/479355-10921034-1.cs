    var process = new Process();
    process.StartInfo = new ProcessStartInfo(Path.GetFullPath(filename));
    process.EnableRaisingEvents = true;
    process.Exited += (a, b) =>
    {
      MessageBox.Show("closed!");
    };
    process.Start();
