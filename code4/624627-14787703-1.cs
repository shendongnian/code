    private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      string selectedFile = "";
      var drive = lstDrive.SelectedValue as Items;
      var folder = lstFolders.SelectedValue as Items;
      var file = lstFiles.SelectedValue as Items;
      selectedFile = drive.ItemString + "\\" + folder.ItemString + "\\" + file.ItemString;
      pictureBox1.Image = Image.FromFile(selectedFile);
    }
