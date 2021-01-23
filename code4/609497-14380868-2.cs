    //public variables
    StringCollection copiedFiles = new StringCollection();
    bool cutWasSelected;
    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CopySelectedFiles();
        cutWasSelected = false;
    }
    private void cutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CopySelectedFiles();
        cutWasSelected = true;
    }
    private void CopySelectedFiles()
    {
        if (listView1.SelectedItems.Count > 0)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                copiedFiles.Add(item.Tag.ToString());
            }
        }
    }
    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string destinationFolder;//however you select this
        PasteCopiedFiles(destinationFolder, cutWasSelected);
        
    }
    private void PasteCopiedFiles(string DestinationFolder, bool deleteSourceFiles)
    {
        if (copiedFiles.Count > 0)
        {
            foreach (string file in copiedFiles)
            {
                if (deleteSourceFiles)
                {
                    File.Move(file,Path.Combine(new string[]{DestinationFolder,Path.GetFileName(file)}));
                }
                else
                {
                    File.Copy(file, Path.Combine(new string[] { DestinationFolder, Path.GetFileName(file) }));
                }
            }
        }
    }
