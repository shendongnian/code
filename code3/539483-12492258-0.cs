    private bool ValidFile(string filename, long limitInBytes, int limitWidth, int limitHeight)
            {
                var fileSizeInBytes = new FileInfo(filename).Length;
                if(fileSizeInBytes > limitInBytes) return false;
    
                using(var img = new Bitmap(filename))
                {
                    if(img.Width > limitWidth || img.Height > limitHeight) return false;
                }
    
                return true;
            }
    
            private void selectImgButton_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if(ValidFile(openFileDialog1.FileName, 102400, 350, 350))
                    {
                        // Image is valid and U can
                        // Do something with image
                        // For example set it to a picture box
                        pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Image is invalid");
                    }
                }
            }
