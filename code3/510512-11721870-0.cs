    private void Create_Controls(string Img_path)
    {
      PictureBox p = new PictureBox();
      p.Size = new Size(138, 100);
      p.Location = new Point(6, 6);
      p.Tag  = Img_path;
      p.BackgroundImage = Image.FromFile(Img_path);
      p.BackgroundImageLayout = ImageLayout.Stretch;
    
      this.Controls.Add(p);
    }
---
    private void Pop_Up()
    {
       MessageBox.Show(p.Tag);
    }
