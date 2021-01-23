            Image image;
            string imagePath = System.IO.Path.Combine(@"C:\Projects_2012\Project_Noam\Files\ProteinPic", comboBox1.SelectedItem.ToString());
            if (System.IO.File.Exists(imagePath))
            {
                image = Image.FromFile(imagePath);
            }
            else
            {
                image = Image.FromFile(@"C:\Projects_2012\Project_Noam\Files\ProteinPic\Empty.png");
            }
            pictureBox1.Image = image;
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
