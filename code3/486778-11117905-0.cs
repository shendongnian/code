    private string patheto = @"C:\temp";
    private void buttonCreate_Click(object sender, EventArgs e)
    {
        string MyFileName = "Car.txt";
        string newPath1 = Path.Combine(patheto, MyFileName);
        Create a folder in the active Directory
        Directory.CreateDirectory(newPath1);
    }
    private void DirectoryPathToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Process.Start(patheto);
    }
