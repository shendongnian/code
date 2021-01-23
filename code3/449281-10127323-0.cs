    cmd.EnableRaisingEvents = true;
    cmd.Exited += new EventHandler(myProcess_Exited);
    private void myProcess_Exited(object sender, System.EventArgs e)
    {
       MessageBox.Show(output.ToString());
    }
