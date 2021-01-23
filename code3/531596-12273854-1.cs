    Process p = new Process();
    p.Exited += new EventHandler(p_Exited);
    p.StartInfo.FileName = @"path to file";
    p.EnableRaisingEvents = true;
    p.Start();
    void p_Exited(object sender, EventArgs e)
    {
        MessageBox.Show("Process exited");
    }
