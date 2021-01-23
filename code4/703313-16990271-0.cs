    radGridView1.MasterTemplate.AutoGenerateColumns = false;
    radGridView1.MasterTemplate.Columns.Add(new GridViewTextBoxColumn("Name"));
    radGridView1.MasterTemplate.Columns.Add(new GridViewTextBoxColumn("Attributes"));
    radGridView1.MasterTemplate.Columns.Add(new GridViewTextBoxColumn("LastAccessTime"));
    radGridView1.MasterTemplate.Columns.Add(new GridViewTextBoxColumn("CreationTime"));
    DirectoryInfo directory = new DirectoryInfo("C:\\");
    FileSystemInfo[] filesInDirectory = directory.GetFileSystemInfos();
    radGridView1.DataSource = filesInDirectory;
