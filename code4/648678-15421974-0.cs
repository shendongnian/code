    ProcessStartInfo psi = new ProcessStartInfo();
    Thread processStarter = new Thread(delegate()
    {
    psi.FileName = "app.exe";
    psi.Arguments = String.Format( "blah blah", port, baud, timeout, job.FullName );
    psi.CreateNoWindow = false;
    psi.ErrorDialog = false;
    psi.WindowStyle = ProcessWindowStyle.Hidden;
    process.StartInfo = psi;
    process.Start();
    process.WaitForExit( job.Timeout );
    //call methods that deal with the files here
    });
    processStarter.IsBackground = true;
    processStarter.Start();
