    p.Click += new EventHandler(Pop_Up);
    
    ...
    
    private void Pop_Up(object sender, EventArgs e)
    {
      var pb = sender as PictureBox;
      if(pb != null)
        MessageBox.Show(pb.ImageLocation);
    }
