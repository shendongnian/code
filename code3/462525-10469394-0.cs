    private void Pic_Click(object sender, System.EventArgs e)
    {
        PictureBox pb = (PictureBox)sender;
        if (_lastPictureBox != null) 
        {
            // update the previous one, eg:
            _lastPictureBox.BackgroundImage = Properties.Resources.FirstImg;
        }
        // now set it to the current one:
        _lastPictureBox = pb;
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
