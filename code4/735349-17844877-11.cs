     for (int i = 0; i < HoweverManyPictureBoxesYouWant; i++)
     {
        PictureBox PB = new PictureBox();
        PB.Name = "PB" + i.ToString();
        PB.Location = new Point(250 * i, 0); //Edit this as you see fit for location, i'm just putting them in a row
        PB.Size = new Size(250, 250);
        PB.ImageLocation = @"C:\PicExample\image" + i.ToString() + ".jpg";
        Controls.Add(PB);
        pictureBoxes.Add(PB); //You only need to do this if you want the PB's in a list for other reasons than setting the image location
     }
