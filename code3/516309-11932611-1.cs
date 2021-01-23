        // For confirm visibility of all images set 
        this.AutoScroll = true;
    
        string[] list = Directory.GetFiles(@"C:\\pictures", "*.jpg");
        PictureBox[] picturebox= new PictureBox[list.Length];
        int y = 100;
        for (int index = 0; index < picturebox.Length; index++)
        {
            this.Controls.Add(picturebox[index]);
            picturebox[index].Location=new Point(index * 120, y);
            if(y%3 == 0)
                y = y + 150;
            picturebox[index ].Size = new Size(100,120);
            picturebox[index].Image = Image.FromFile(list[index]);
        }
