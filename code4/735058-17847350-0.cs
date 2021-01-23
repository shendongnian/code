    private void buttonLayout_Click(object sender, EventArgs e)
        {
            int x=0;
            int y=0;          
            for (int index = 0; index < 6;index++ )
            {
                string path = @"C:\Pictures\" + index.ToString() + ".png";
                if (!File.Exists(path))
                {
                    continue;
                }
                Image image=Image.FromFile(path);
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.Left = x;
                pictureBox.Top = y;
                pictureBox.Width = image.Width;
                pictureBox.Height = image.Height;
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                panelPictures.Controls.Add(pictureBox);
                x += pictureBox.Image.Width;               
            }            
        }
