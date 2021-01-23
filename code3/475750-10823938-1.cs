    private void FormMain_Load(object sender, EventArgs e)
            {
                SensitiveInformation sensitiveInformation = new SensitiveInformation();
                int index = 0;
                //foreach (var photo in Flickr.LoadLatestPhotos(sensitiveInformation.ScreenName))
                for (int i = 0; i < 10; i++)
                {
                    SelectablePictureBox pictureBox = new SelectablePictureBox(index);
    
                    // subscribe to picture box's event
                    pictureBox.OnPicBoxKeyDown += new PreviewKeyDownEventHandler(pictureBox_OnPicBoxKeyDown);
                    PictureGallery.Controls.Add(pictureBox);
                    index++;
                }
            }
    // this code does the selection. Query the FLowLayout control which is the 1st one and select all the selected ones
    void pictureBox_OnPicBoxKeyDown(object sender, PreviewKeyDownEventArgs e)
            {
                if (e.KeyCode != Keys.Space) return;
                foreach (SelectablePictureBox item in Controls[0].Controls)
                {
                    if (item.IsHighlighted)
                    {
                        item.SetToSelected();
                    }
                }
            }
