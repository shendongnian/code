    private void button1_Click(object sender, EventArgs e)
    {
        Process p = new Process();
        p.StartInfo.FileName = Application.ExecutablePath;
        p.Start();
    }
