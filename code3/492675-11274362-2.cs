    myProcess.EnableRaisingEvents = true;
    myProcess.Exited += new EventHandler(myProcess_Exited);
    myProcess.Start();
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
        // reenable button
    }
