    using(Image img = Image.FromFile(open.FileName))
    {
       part.Picture = img; 
    }
    pictureBox1.InitialImage = null;
    pictureBox1.Image = part.Picture;  //Picture  is a propery in a class
