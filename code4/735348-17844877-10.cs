      List<PictureBox> pictureBoxes = new List<PictureBox>();
      List<string> imageLocations = new List<string>();
    
      private void Form1_Load(object sender, EventArgs e)
      {
         PictureBox PB1 = new PictureBox();
         PB1.Location = new Point(0, 0);
         PB1.Size = new Size(144, 197);
         Controls.Add(PB1);
         PictureBox PB2 = new PictureBox();
         PB2.Location = new Point(145, 0);
         PB2.Size = new Size(327, 250);
         Controls.Add(PB2);
         pictureBoxes.Add(PB1);
         pictureBoxes.Add(PB2);
         imageLocations.Add(@"C:\PicExample\image1.jpg");
         imageLocations.Add(@"C:\PicExample\image2.jpg");
         for (int i = 0; i < pictureBoxes.Count && i < imageLocations.Count; i++)
         {
            pictureBoxes[i].ImageLocation = imageLocations[i];
         }
      }
