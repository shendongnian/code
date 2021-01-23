    try 
    {
        string pathUser4 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string pathDownload4 = (pathUser4 + @"\Downloads\");
        string sourceFile = pathDownload4 + listBox1.Text;
        string pathdoc5 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string pathDownload5 = (pathdoc5 + @"\iracing\setups\");
        string destinationFile = pathDownload5 + comboBox1.Text;
        File.Move(sourceFile, destinationFile);
        if (comboBox1.Text == "Select File Destination")
        {
            MessageBox.Show("Please Select A Destination Folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
    }
    catch (Exception e)
    {
        File.AppendAllText("ErrorLog.txt", e.ToString() + "\n");
    }
