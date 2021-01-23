    private void btnFiles_Click(object sender, EventArgs e)
    {
      ICloudProvider.UploadingList objUpload = ICloudProvider.UploadingList.Instance;
      if(objUpload!=null)
      {
        objUpload.Show();
      }
    }
