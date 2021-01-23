        // For confirm visibility of all images set 
        this.AutoScroll = true;
    
        string[] list = Directory.GetFiles(@"C:\pictures", "*.jpg");
        PictureBox[] picturebox= new PictureBox[list.Length];
        int y = 0;
        for (int index = 0; index < picturebox.Length; index++)
        {
            this.Controls.Add(picturebox[index]);
            // Following three lines set the images(picture boxes) locations
            if(index % 3 == 0)
                y = y + 150; // 3 images per rows, first image will be at (20,150)
            picturebox[index].Location=new Point(index * 120 + 20, y);
            picturebox[index ].Size = new Size(100,120);
            picturebox[index].Image = Image.FromFile(list[index]);
        }
