    private void timer1_Tick(object sender, EventArgs e) {
      Process service = new Process();
      var pi = new ProcessStartInfo(exePath, null);
      pi.UseShellExecute = false;        
      service.StartInfo = pi;
      //start the process
      service.Start();
    }
