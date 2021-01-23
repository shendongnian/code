    private void fileSystemWatcherMCH1_Changed(object sender, System.IO.FileSystemEventArgs e)
    {
        try
        {
            string machState = File.ReadAllLines(@"C:\Users\sgarner\Documents\PROTOMET SHOP FLOOR\Machines\MACHINE_1.txt").Last();
            btnMCH1.Text = machState;
            btnMCH1.BackColor = Color.Blue;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Messasge);
        }
    }
