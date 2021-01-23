    PictureBox[] pictureBoxes = { PictureBox1, PictureBox2, PictureBox3, PictureBox4 };
    Image[] images = { ImageHere1, ImageHere2, ImageHere3, ImageHere4 };
    for (int i = 0; i < pictureBoxes.Length; i++)
    {
        pictureBoxes[i].Image = images[i];
    }
