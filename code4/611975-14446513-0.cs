    var imagePath = dtTemp.Columns[3].ToString();
    if (File.Exists(imagePath))
    {
        var image = Image.FromFile(imagePath);
        pictureBox1.Image = image;
    }
    else
    {
        throw new FileNotFoundException(); 
        // of course something more subtle is advisable
    }
