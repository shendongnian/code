    class MyPictureViewer
    {
       protected string[] pFileNames;
       protected int pCurrentImage = -1;
    
       private void openButton_Click(object sender, EventArgs e)
       {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG|*.jpg|Bitmaps|*.bmp";
    
            if(openFileDialog.ShowDialog()== DialogResult.OK)
            {
                pFileNames = openFileDialog.FileNames;
                pCurrentImage=0;
                ShowCurrentImage();
            }
       }
    
       protected void ShowCurrentImage()
       {
          if(pCurrentImage >= 0 && pCurrentImage < pFileNames.Length-1)
          {
              pictureBox1.Image = Bitmap.FromFile(pFileNames[pCurrentImage]);
          }
       }
    }
