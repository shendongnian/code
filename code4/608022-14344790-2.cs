    string path = txtPath.Text;
    string outputDir = txtArchiveTo.Text
    string finalDir = System.IO.Path.Combine(outputDir, path.Remove(0, System.IO.Path.GetPathRoot(path).Length));
    
    DirectoryInfo di = new DirectoryInfo(txtPath.Text);
    WalkDirectoryTree(di, finalDir);
