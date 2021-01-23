    private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
      selectedFile = "";
      var drive = lstDrive.SelectedValue as Item;
      var folder = lstFolders.SelectedValue as Item;
      var file = lstFiles.SelectedValue as Item;
      selectedFile = drive.ItemString + "\\" + folder.ItemString + "\\" + file.ItemString;
      pictureBox1.Image = Image.FromFile(selectedFile);
    }
