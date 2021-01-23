            if (fileEntries.Length == 0)
            {
                Image image = Image.FromFile("Path of empty.png");
                pictureBox1.Image = image;
                pictureBox1.Height = image.Height;
                pictureBox1.Width = image.Width;
            }
            else
            {
                foreach (string fileName in fileEntries)
                {
                    if (fileName.Contains(comboBox1.SelectedItem.ToString()))
                    {
                        Image image = Image.FromFile(fileName);
                        pictureBox1.Image = image;
                        pictureBox1.Height = image.Height;
                        pictureBox1.Width = image.Width;
                    }
                }
            }
