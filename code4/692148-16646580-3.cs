    pictureBox1.LoadCompleted += pictureBox1_LoadCompleted;
        
    pictureBox1.InitialImage = Image.FromFile(@"... path to waiting-to-load image ...");
    pictureBox1.ImageLocation = <...path to image...>;
    pictureBox1.LoadAsync(); // perform loading
    
    void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e) {
        // do something with loaded image
    }
