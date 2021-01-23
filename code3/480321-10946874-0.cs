    foreach (string fileName in fileEntries)
    {
       if (fileName.Contains(comboBox1.SelectedItem.ToString()))
       {
         pictureBox1.Image = Image.FromFile(fileName);              
       }
       else
       {
         pictureBox1.Image = ImageFromFile("Empty.png");                
       }
       // Set the PictureBox image property to this image.
       // ... Then, adjust its height and width properties.
       pictureBox1.Image = image;
       pictureBox1.Height = image.Height;
       pictureBox1.Width = image.Width;
    }
