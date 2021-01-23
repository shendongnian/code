    private void LinkLabel_Click(object sender, System.EventArgs e)
    {
        string PlayListFile = sender.Text;
        Process.Start("wmplayer.exe", PlayListFile);
    }
