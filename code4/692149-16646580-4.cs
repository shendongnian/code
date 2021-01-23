    panel1.AutoScroll = true;
    panel1.Height = 1000;
    for(int i = 0; i < 5; i++) {
        PictureBox pb = new PictureBox();
        pb.Dock = DockStyle.Top;
        pb.Height = panel1.Height/2;
        pb.WaitOnLoad = false;
        pb.InitialImage = Image.FromFile("WaitingToLoad.gif");
        pb.ImageLocation = @"https://www.google.com/images/srpr/logo4w.png";
        pb.LoadCompleted += pb_LoadCompleted;
        pb.Parent = panel1;
        pb.LoadAsync(); //<<<<<
    }
    //
    void pb_LoadCompleted(object sender, AsyncCompletedEventArgs e) {
        MessageBox.Show("Load completed!");
    }
