    public FileList()
    {
        InitializeComponent();
        //Sets Drive Choices
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo d in drives)
        {
            driveChoice.Items.Add(d);
        }
    }
    //Find Video Files
    private void btnStart_Click(object sender, EventArgs e)
    {            
        String path = driveChoice.Text;
        if (path != "C:\\")
        {
            DirectoryInfo root = new DirectoryInfo(path);
            var rootFiles = root.GetFiles("*.avi");
            var rootDirs = root.GetDirectories("*", SearchOption.TopDirectoryOnly).Where(d => !d.Name.Equals("System Volume Information") && !d.Name.Equals("$RECYCLE.BIN"));
            foreach (var file in rootFiles)
            {
                tbFileList.Text = tbFileList.Text + file.FullName + "\r\n";
            }
            foreach (var dir in rootDirs)
            {
                foreach (var dirFile in dir.GetFiles("*.avi", SearchOption.AllDirectories))
                {
                    tbFileList.Text = tbFileList.Text + dirFile.FullName + "\r\n";
                }
            }
        }
        else
        {
            Application.Exit();
        }
    }
