    try
    {
        myProcess.EnableRaisingEvents = true;
        myProcess.Exited += new EventHandler(myProcess_Exited);
        myProcess.Start();
        // disable button
    }
    catch()
    {
        // enable button
    }
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
        // enable button
    }
