    PictureBox _lastPictureBox = null;
    Image _lastPictureBoxImage = null;
    private void Pic_Click(object sender, System.EventArgs e)
    {
        PictureBox pb = (PictureBox)sender;
        if (_lastPictureBox != null) 
        {
          // update the previous one, eg:
           _lastPictureBox.BackgroundImage = _lastPictureBoxImage;
        }
        // now set it to the current one:
       _lastPictureBox = pb;
       _lastPictureBoxImage = pb.Image;
       switch (pb.Name)
       {
         case "1": 
           pb.BackgroundImage = Properties.Resources.OtherImg; //creates the background
           pb.BackgroundImageLayout = ImageLayout.Stretch;
        break;
        case "2":
          pb.BackgroundImage = Properties.Resources.OtherImg; //creates the background
          pb.BackgroundImageLayout = ImageLayout.Stretch;
        break;
      }
   }
