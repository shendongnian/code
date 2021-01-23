    public void selectFolder(Label label, string writePath)
        {
            FolderBrowserDialog Tree = new FolderBrowserDialog();
            Tree.RootFolder = Environment.SpecialFolder.MyComputer;
            Tree.ShowNewFolderButton = false;
            Tree.Description = "Please Select any Drive OR Folder on Your External hard Drive";
            Tree.ShowDialog();
            if (Tree.SelectedPath.Length != 0)
            {
                label.Text = Tree.SelectedPath.ToString();
                Properties.Settings.Default.WritePath01 = label.Text;
                Properties.Settings.Default.Save();
            }
        }
        private void FolderSelector_Click(object sender, EventArgs e)
        {
            selectFolder(sender as Label, Properties.Settings.Default.WritePath01);
        }
