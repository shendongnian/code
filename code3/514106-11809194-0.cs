    private void button1_Click(object sender, EventArgs e)
        {
            //make your loop here
            pictureBox1.WaitOnLoad = false;
            pictureBox1.LoadCompleted += new AsyncCompletedEventHandler(pictureBox1_LoadCompleted);
            pictureBox1.LoadAsync(albumPhoto.URL);
        }
    
        void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //now your picture is loaded, add to list view
             CheckBox selectedPhotoCheckBox = new CheckBox();
             listBoxPictures.Items.Add(albumsImg);
             listBoxPictures.Items.Add(selectedPhotoCheckBox);
        }
